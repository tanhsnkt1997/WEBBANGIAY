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
    public class BandnersController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/Bandners
        public ActionResult Index()
        {
            return View(db.Bandners.ToList());
        }

        // GET: admin/Bandners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandner bandner = db.Bandners.Find(id);
            if (bandner == null)
            {
                return HttpNotFound();
            }
            return View(bandner);
        }

        // GET: admin/Bandners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Bandners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Image,Link,CreatedDate,CreatedBy,Status")] Bandner bandner, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    //filename = Guid.NewGuid().ToString() + img.FileName;
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("/Content/upload/baner"), filename);
                    img.SaveAs(path);
                    bandner.Image = filename; //Lưu ý
                }
                else
                {
                    bandner.Image = "logo_l.png";
                }
                bandner.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.Bandners.Add(bandner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bandner);
        }

        // GET: admin/Bandners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandner bandner = db.Bandners.Find(id);
            if (bandner == null)
            {
                return HttpNotFound();
            }
            return View(bandner);
        }




        // POST: admin/Bandners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Image,Link,CreatedDate,CreatedBy,Status")] Bandner bandner, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    //filename = Guid.NewGuid().ToString() + img.FileName;
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("/Content/upload/baner"), filename);
                    img.SaveAs(path);
                    bandner.Image = filename; //Lưu ý
                }
                else
                {
                    bandner.Image = "logo_l.png";
                }
                bandner.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.Entry(bandner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bandner);
        }

        // GET: admin/Bandners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandner bandner = db.Bandners.Find(id);
            if (bandner == null)
            {
                return HttpNotFound();
            }
            return View(bandner);
        }

        // POST: admin/Bandners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bandner bandner = db.Bandners.Find(id);
            db.Bandners.Remove(bandner);
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
