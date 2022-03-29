using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            //Gan cac gia tri nguoi dung nhap lieu cac bien
            var user = collection["User"];
            var password = collection["Password"];
            if (String.IsNullOrEmpty(user))
            {
                ViewData["err1"] = "Bạn cần nhập username";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["err2"] = "Bạn cần nhập mật khẩu";
            }
            else
            {
                //Gan gia tri cho doi tuong duoc tao moi (customer)
                user ct = data.users.SingleOrDefault(n => n.username == user && n.password == password);
                if (ct != null)
                {
                    ViewBag.Notification = "Chúc mừng bạn đăng nhập thành công";
                    Session["username"] = ct;
                    return RedirectToAction("ListBook", "Book");
                }
                else
                {
                    ViewBag.Notification = "Tên đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Books");
        }
    }
}