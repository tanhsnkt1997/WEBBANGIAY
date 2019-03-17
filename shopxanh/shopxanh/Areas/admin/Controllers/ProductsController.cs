using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model.EF;
using System.IO;
using shopxanh.Help;

namespace shopxanh.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/Products
        public ActionResult Index(long?id =null)
        {
            getCatogory(id);
            return View();
        }

        public void getCatogory(long? selectdId=null)
        {
            ViewBag.Catogory=new SelectList(db.ProductCategories.Where(x=>x.Status==true) , "ID", "Name", selectdId);
        }
        public ActionResult getProduct(long? id)
        {
            if(id==null)
            {
                var v = db.Products.ToList();
                return PartialView(v);
            }
            var m = db.Products.Where(x => x.CategoryID == id).ToList();
            return PartialView(m);
        }
        // GET: admin/Products/Details/5
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

        // GET: admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            return View();
        }

        // POST: admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,Detail,Alias,CategoryID,Image,MoreImages,Price,PriceDown,Warranty,Description,Content,MetaKeyword,MetaDescription,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status,HomeFlag,HotFlag,ViewCount")] Product product, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    //filename = Guid.NewGuid().ToString() + img.FileName;
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("/Content/images"), filename);
                    img.SaveAs(path);
                    product.Image = filename; //Lưu ý

                }
                else
                {
                    product.Image = "logo_l.png";
                }
                
                product.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                product.MetaTitle = Functions.ConvertToUnSign(product.Name);

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: admin/Products/Edit/5
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
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,Detail,Alias,CategoryID,Image,MoreImages,Price,PriceDown,Warranty,Description,Content,MetaKeyword,MetaDescription,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,Status,HomeFlag,HotFlag,ViewCount")] Product product, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    //filename = Guid.NewGuid().ToString() + img.FileName;
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("/Content/images"), filename);
                    img.SaveAs(path);
                    product.Image = filename; //Lưu ý

                }
                else
                {
                    product.Image = "logo_l.png";
                }


                product.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                product.MetaTitle = Functions.ConvertToUnSign(product.Name);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }
        // GET: admin/Products/Delete/5
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

        // POST: admin/Products/Delete/5
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
