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
    public class SlidesController : Controller
    {
        private ShoponlineDB db = new ShoponlineDB();

        // GET: admin/Slides
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: admin/Slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: admin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Slides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Image,Description,URL,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] Slide slide, HttpPostedFileBase img)
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
                    slide.Image = filename; //Lưu ý

                }
                else
                {
                    slide.Image = "logo_l.png";
                }


                slide.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.Slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        
            return View(slide);
        }

        // GET: admin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: admin/Slides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,Image,Description,URL,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] Slide slide, HttpPostedFileBase img)
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
                    slide.Image = filename; //Lưu ý

                }
                else
                {
                    slide.Image = "logo_l.png";
                }


                slide.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString());
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(slide);
        }

        // GET: admin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = db.Slides.Find(id);
            db.Slides.Remove(slide);
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
