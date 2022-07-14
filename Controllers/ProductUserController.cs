using OnlineShoppingDemo2.Migrations;
using OnlineShoppingDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingDemo2.Controllers
{
   
    public class ProductUserController : Controller
    {
        // GET: ProductUser
        private DataContext db = new DataContext();

        List<Models.Cart> cart = new List<Models.Cart>();



        public ActionResult ShowDetails(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


       
        public ActionResult Cart(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if(product==null)
            {
                return HttpNotFound();
            }


            cart.Add(new Models.Cart(product.Id, product.Name, product.ImageUrl));

            

            return View(cart.ToList());
        }

        
       

       

    }
}