using shopxanh.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dao;
using shopxanh.Common;

namespace shopxanh.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login_admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.UserName, model.PassWord);
                if (result)
                {
                    var user = dao.getById(model.UserName);
                    var userSeasion = new UserLogin
                    {
                        UserName = user.UserName,
                        userID = user.ID
                    };
                    Session.Add(CommonConstants.USER_SESSION, userSeasion);
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }

            }
            return View("Index");

        }
    }
}