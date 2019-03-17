using BotDetect.Web.Mvc;
using model.Dao;
using model.EF;
using shopxanh.Common;
using shopxanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopxanh.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.getById(model.UserName);
                    var userSeasion = new UserLogin
                    {
                        UserName = user.UserName,
                        userID = user.ID
                    };
                    Session.Add(CommonConstants.USER_SESSION, userSeasion);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }

            }
            return View(model);

        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }



        [HttpPost]
        
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new userDao();
                if(dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");

                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result=dao.Insert(user);
                    if (result>0)
                    {
                        ViewBag.Success = "Đăng kí thành công";
                        model = new RegisterModel();

                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }


            }
            return View(model);
        }
        
    }
}