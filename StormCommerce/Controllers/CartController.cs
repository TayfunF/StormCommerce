using StormCommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StormCommerce.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context = new AppDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            //Cart cart = (Cart)Session["Cart"];
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult _SummaryPartial()
        {
            return PartialView(GetCart());
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            var Cart = GetCart();

            if (Cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır");
            }

            if (ModelState.IsValid)
            {
                //Siparişi veritabanına kaydet
                //Kartı sıfırla
                SaveOrder(Cart, shippingDetails);

                Cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails shippingDetails)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString();
            order.Total = cart.TotalProduct();
            order.OrderDate = DateTime.Now;
            order.Username = shippingDetails.Username;
            order.AddressTitle = shippingDetails.AddressTitle;
            order.Address = shippingDetails.Address;
            order.City = shippingDetails.City;
            order.Distinct = shippingDetails.Distinct;
            order.PostalCode = shippingDetails.PostalCode;
            order.OrderLines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;

                order.OrderLines.Add(orderline);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}