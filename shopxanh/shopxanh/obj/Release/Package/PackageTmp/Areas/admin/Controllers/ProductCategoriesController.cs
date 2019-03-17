using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model.EF;

namespace shopxanh.Areas.admin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: admin/ProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategorie productCategorie = db.ProductCategories.Find(id);
            if (productCategorie == null)
            {
                return HttpNotFound();
            }
            return View(productCategorie);
        }

        // GET: admin/ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,Alias,Description,ParentID,DisplayOrder,Image,MetaKeyword,MetaDescription,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status,HomeFlag")] ProductCategorie productCategorie)
        {
            if (ModelState.IsValid)
            {
                productCategorie.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.ProductCategories.Add(productCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategorie);
        }

        // GET: admin/ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategorie productCategorie = db.ProductCategories.Find(id);
            if (productCategorie == null)
            {
                return HttpNotFound();
            }
            return View(productCategorie);
        }

        // POST: admin/ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,Alias,Description,ParentID,DisplayOrder,Image,MetaKeyword,MetaDescription,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status,HomeFlag")] ProductCategorie productCategorie)
        {
            if (ModelState.IsValid)
            {
                productCategorie.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.Entry(productCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategorie);
        }

        // GET: admin/ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategorie productCategorie = db.ProductCategories.Find(id);
            if (productCategorie == null)
            {
                return HttpNotFound();
            }
            return View(productCategorie);
        }

        // POST: admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategorie productCategorie = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(productCategorie);
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
