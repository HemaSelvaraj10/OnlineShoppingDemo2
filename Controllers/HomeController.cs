using OnlineShoppingDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingDemo2.Controllers
{
    public class HomeController : Controller
    {

        private DataContext db = new DataContext();

        public ActionResult Index()
        {

            char product = db.Products.ToList();
            return View(product);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

           












    }
}