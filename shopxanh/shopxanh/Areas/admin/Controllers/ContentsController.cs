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

namespace shopxanh.Areas.admin.Controllers
{
    public class ContentsController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/Contents
        public ActionResult Index()
        {
            return View(db.Contents.ToList());
        }

        // GET: admin/Contents/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: admin/Contents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Meta_title,Description,Image,Detail,CreatedBy,CreatedDate,MetaKeywords,Status")] Content content, HttpPostedFileBase img)
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
                    content.Image = filename; //Lưu ý

                }
                else
                {
                    content.Image = "logo_l.png";
                }
                content.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());


                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

          
            return View(content);
        }

        // GET: admin/Contents/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }


        
        // POST: admin/Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,Meta_title,Description,Image,Detail,CreatedBy,CreatedDate,MetaKeywords,Status")] Content content, HttpPostedFileBase img)

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
                    content.Image = filename; //Lưu ý

                }
                else
                {
                    content.Image = "logo_l.png";
                }
                content.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());


                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(content);
        }
        // GET: admin/Contents/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: admin/Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
