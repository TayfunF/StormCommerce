using StormCommerce.Models;
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
            return View(_context.Products.Where(x => x.IsHome && x.IsApproved).ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            return View(_context.Products.Where(x=>x.Id == id).FirstOrDefault());
        }

        public ActionResult ProductList()
        {
            return View(_context.Products.Where(x => x.IsApproved).ToList());
        }
    }
}