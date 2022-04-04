using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.TotalBook = Total_Book();
            ViewBag.TotalCategory = Total_Category();
            ViewBag.TotalOrderFalse = Total_OrderFalse();
            ViewBag.TotalMoney = Total_Money();
            return View();
        }

        public int Total_Book()
        {
            int total = 0;
            foreach (var item in data.Books)
            {
                total++;
            }
            return total;
        }

        public int Total_Category()
        {
            int total = 0;
            foreach (var item in data.categories)
            {
                total++;
            }
            return total;
        }

        public int Total_OrderFalse()
        {
            int total = 0;
            foreach (var item in data.orders)
            {
                if (item.status == false)
                {
                    total++;
                }
            }
            return total;
        }

        public double Total_Money()
        {
            double total = 0;
            var sql = from o in data.orders
                      join ol in data.order_lists
                      on o.id equals ol.id_order
                      where o.status == true
                      select new TotalMoney
                      {
                          price = Convert.ToDouble(ol.unit_price)
                      };
            foreach (var item in sql)
            {
                total += item.price;
            }
            return total;
        }
    }
}