using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dao;
using shopxanh.Areas.admin.Models;

namespace shopxanh.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
           
            return PartialView(list);
        }
        
        public ActionResult Menutop()
        {
            var moddel = new Getmenu().listbygroupuid(1);
            return PartialView(moddel);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult Menumain()
        {
            var model = new Getmenu().listbygroupuid(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult getfooter()
        {
            ViewBag.getmenuinfooter = new Getmenu().listbygroupuid(2);
            var model = new getfooter().listall();
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult getbaner()
        {
            var model = new getbaner().listall();
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult getslide()
        {
            var model = new getslide().listall();
            return PartialView(model);
        }
    }
}