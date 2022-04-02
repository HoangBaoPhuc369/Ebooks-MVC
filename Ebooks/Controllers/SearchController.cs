using Ebooks.Areas.Admin.Models;
using Ebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book = Ebooks.Models.Book;

namespace Ebooks.Controllers
{
    public class SearchController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tags)
        {
            Book c = data.Books.Where(x => x.title.Equals(tags)).SingleOrDefault();
            return View(c);
        }
        public JsonResult getcompanies()
        {
            List<Book> li = data.Books.OrderBy(x => x.title).ToList();

            return Json(li, JsonRequestBehavior.AllowGet);
        }

    }
}