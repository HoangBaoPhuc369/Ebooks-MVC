using Ebooks.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Areas.Admin.Controllers
{
    public class CustomerMangeController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();
        // GET: Admin/Customer

        public ActionResult MangeCustomer()
        {
            var all_customer = from c in data.customers select c;
            return View(all_customer);
        }

        public ActionResult Edit(int id)
        {
            var E_customer = data.customers.First(m => m.id == id);
            return View(E_customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_customer = data.customers.First(m => m.id == id);
            var E_type = collection["Type"];
            E_customer.id = id;
            E_customer.type = Convert.ToByte(collection["Type"]);

            UpdateModel(E_customer);
            data.SubmitChanges();

            return RedirectToAction("MangeCustomer");
        }

        public ActionResult Delete(int id)
        {
            var D_Customer = data.customers.Where(m => m.id == id).First();
            data.customers.DeleteOnSubmit(D_Customer);
            data.SubmitChanges();
            return RedirectToAction("MangeCustomer");
        }
    }
}