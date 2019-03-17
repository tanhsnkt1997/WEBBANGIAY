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
    public class ContantsController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/Contants
        public ActionResult Index()
        {
            return View(db.Contants.ToList());
        }

        // GET: admin/Contants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contant contant = db.Contants.Find(id);
            if (contant == null)
            {
                return HttpNotFound();
            }
            return View(contant);
        }

        // GET: admin/Contants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Contants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Text")] Contant contant)
        {
            if (ModelState.IsValid)
            {
                db.Contants.Add(contant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contant);
        }

        // GET: admin/Contants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contant contant = db.Contants.Find(id);
            if (contant == null)
            {
                return HttpNotFound();
            }
            return View(contant);
        }

        // POST: admin/Contants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Text")] Contant contant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contant);
        }

        // GET: admin/Contants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contant contant = db.Contants.Find(id);
            if (contant == null)
            {
                return HttpNotFound();
            }
            return View(contant);
        }

        // POST: admin/Contants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contant contant = db.Contants.Find(id);
            db.Contants.Remove(contant);
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
