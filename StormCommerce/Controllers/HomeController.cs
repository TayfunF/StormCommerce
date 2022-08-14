using StormCommerce.Models;
using StormCommerce.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StormCommerce.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context = new AppDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var Urunler = _context.Products.Where(p => p.IsHome && p.IsApproved).Select(p => new ProductVM()
            {
                Id = p.Id,
                Name = p.Name.Length > 50 ? p.Name.Substring(0, 47) + "..." : p.Name,
                Description = p.Description.Length > 50 ? p.Description.Substring(0, 47) + "..." : p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Image = p.Image == null ? "resim-yok.png" : p.Image,
                CategoryId = p.CategoryId,
            }).ToList();

            return View(Urunler);
        }

        public ActionResult ProductDetails(int id)
        {
            return View(_context.Products.Where(x => x.Id == id).FirstOrDefault());
        }

        public ActionResult ProductList(int? id)
        {
            var Urunler = _context.Products.Where(p => p.IsApproved).Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name.Length > 50 ? p.Name.Substring(0, 47) + "..." : p.Name,
                Description = p.Description.Length > 50 ? p.Description.Substring(0, 47) + "..." : p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Image = p.Image,
                CategoryId = p.CategoryId,
            }).AsQueryable();

            if (id != null)
            {
                Urunler = Urunler.Where(p => p.CategoryId == id);
            }

            ViewBag.ProductCount = Urunler.Count();

            return View(Urunler.ToList());
        }

        public PartialViewResult GetCategoryList()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}