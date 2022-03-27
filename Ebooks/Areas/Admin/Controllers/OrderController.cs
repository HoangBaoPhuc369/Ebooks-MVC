using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/Order
        public ActionResult Orders()
        {
            //var x = data.orders.Where(n => n.id == order_list.)
            //var query = from o in data.orders
            //            join ol in data.order_lists on o.id equals ol.id_order
            //            group o by new { o.date_create, o.status, o.order_lists } into g
            //            select new
            //            {
            //                DateCreate = g.Key.date_create,
            //                //CustomerName = c.name,
            //                Amount = g.Sum(n => n.order_l),
            //                Total = ol.unit_price,
            //                Status = o.status,
            //            };
            return View();
        }
    }
}