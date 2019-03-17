using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dao;


namespace shopxanh.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            var model = new getcontent().listcontent();
            return View(model);
        }
        public ActionResult detailcontent( long id)
        {
            var getcontent = new getcontent().viewDetail(id);
            ViewBag.cotentgetsl = new getcontent().listofcontent(id);
            return View(getcontent);
        }
    }
}