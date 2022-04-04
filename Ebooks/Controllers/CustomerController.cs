using Ebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Controllers
{
    public class CustomerController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //Ham Post nhan du lieu tu trang Register va thuc hien viec tao moi du lieu
        [HttpPost]
        public ActionResult Register(FormCollection collection, customer ct)
        {
            //Gan cac gia tri nguoi dung nhap lieu cac bien
            var user = collection["User"];
            var password = collection["Password"];
            var confirm_pw = collection["Confirm_pw"];
            var email = collection["Email"];
            if(String.IsNullOrEmpty(user))
            {
                ViewData["err1"] = "Bạn cần nhập username";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["err2"] = "Bạn cần nhập email";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["err3"] = "Bạn cần nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(confirm_pw))
            {
                ViewData["err4"] = "Bạn cần xác thực lại mật khẩu";
            }
            else if (confirm_pw != password)
            {
                ViewData["err4"] = "Bạn cần nhập đúng mật khẩu";
            }
            else
            {
                //Gan gia tri cho doi tuong duoc tao moi (customer)
                ct.username = user;
                ct.password = password;
                ct.email = email;
                ct.image_path = "~/Content/no_pic.jpg";
                data.customers.InsertOnSubmit(ct);
                data.SubmitChanges();
                return RedirectToAction("Login");
            }
            return this.Register();
        }

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
                customer ct = data.customers.SingleOrDefault(n => n.username == user && n.password == password);
                if (ct != null)
                {
                    ViewBag.Notification = "Chúc mừng bạn đăng nhập thành công";
                    Session["username"] = ct;
                    return RedirectToAction("Index","Books");
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


        public ActionResult CustomerInfo(int id)
        {
            var E_user = data.customers.First(m => m.id == id);
            return View(E_user);
        }

        [HttpPost]
        public ActionResult CustomerInfo(int id, FormCollection collection)
        {
            var E_user = data.customers.First(m => m.id == id);
            var E_tendn = collection["Username"];
            var e_hinh = collection["image_path"];
            var E_ten = collection["Name"];
            var E_email = collection["Email"];
            var E_diachi = collection["Address"];
            var Esdt = collection["Contact"];
            E_user.id = id;
            if (string.IsNullOrEmpty(E_tendn))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_user.username = E_tendn;
                E_user.image_path = E_tendn;
                E_user.name = E_ten;
                E_user.email = E_email;
                E_user.address = E_diachi;
                E_user.contact = Esdt;
                Session["username"] = E_user;
                UpdateModel(E_user);
                data.SubmitChanges();
                return this.CustomerInfo(id);
            }
            return this.CustomerInfo(id);
        }
        //-----------------------------------------


    }
}