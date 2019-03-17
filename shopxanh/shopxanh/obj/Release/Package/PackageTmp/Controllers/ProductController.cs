using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dao;

namespace shopxanh.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [OutputCache(CacheProfile = "Cache1DayForProduct")]
        public ActionResult Index(long id)
        {
            var product = new productdao().viewDetail(id);
            ViewBag.Centagory = new productcentagory().viewDetail(product.CategoryID);
            ViewBag.RelatedProducts = new productdao().listrealedProduct(id);
            return View(product);
        }
        public JsonResult ListName(string q)
        {
            var data = new productdao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new productdao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public PartialViewResult productcentagory()
        {
            var model = new productcentagory().listall();
            return PartialView(model);
        }
        public ActionResult listnewproduct()
        {
            var model = new listnewproduct().listnew(5);
            return PartialView(model);

        }
        public ActionResult listfeatureproduct()
        {
            
            var model = new featureproduct().lisfeature(4);
            return PartialView(model);

        }
        public ActionResult centagory(long CateId, int page = 1, int pageSize = 4)
        {
            ViewBag.Centagory = new productcentagory().viewDetail(CateId);
            int totalRecord = 0;
            var model = new productdao().listbycategoryid(CateId, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage= (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;




            return View(model);
        }


    }
}