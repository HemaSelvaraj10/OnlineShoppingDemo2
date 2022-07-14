using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingDemo2.Models;

namespace OnlineShoppingDemo2.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CateId,Price")] Product product,HttpPostedFileBase UploadImage,HttpPostedFileBase UploadImage1, HttpPostedFileBase UploadImage2, HttpPostedFileBase UploadImage3)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" ||
                        UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "image/gif" ||
                        UploadImage.ContentType == "image/jpeg")
                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Images/" + UploadImage.FileName);
                        product.ImageUrl = UploadImage.FileName;
                    }
                    else
                    {
                        return View();
                    }
                }

                if (UploadImage1 != null)
                {
                    if (UploadImage1.ContentType == "image/jpg" || UploadImage1.ContentType == "image/png" ||
                        UploadImage1.ContentType == "image/bmp" || UploadImage1.ContentType == "image/gif" ||
                        UploadImage1.ContentType == "image/jpeg")
                    {
                        UploadImage1.SaveAs(Server.MapPath("/") + "/Images/" + UploadImage1.FileName);
                        product.ImageUrl1 = UploadImage1.FileName;
                    }
                    else
                    {
                        return View();
                    }
                }

                if (UploadImage2 != null)
                {
                    if (UploadImage2.ContentType == "image/jpg" || UploadImage2.ContentType == "image/png" ||
                        UploadImage2.ContentType == "image/bmp" || UploadImage2.ContentType == "image/gif" ||
                        UploadImage2.ContentType == "image/jpeg")
                    {
                        UploadImage2.SaveAs(Server.MapPath("/") + "/Images/" + UploadImage2.FileName);
                        product.ImageUrl2 = UploadImage2.FileName;
                    }
                    else
                    {
                        return View();
                    }
                }

                if (UploadImage3 != null)
                {
                    if (UploadImage3.ContentType == "image/jpg" || UploadImage3.ContentType == "image/png" ||
                        UploadImage3.ContentType == "image/bmp" || UploadImage3.ContentType == "image/gif" ||
                        UploadImage3.ContentType == "image/jpeg")
                    {
                        UploadImage3.SaveAs(Server.MapPath("/") + "/Images/" + UploadImage3.FileName);
                        product.ImageUrl3 = UploadImage3.FileName;
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName",product.CateId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageUrl,ImageUrl1,ImageUrl2,ImageUrl3,Price,CateId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
