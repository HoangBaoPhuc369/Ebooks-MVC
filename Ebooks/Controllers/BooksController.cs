using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Ebooks.Models
{
    public class BooksController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Books
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_sach = (from s in data.Books select s).OrderBy(m => m.id);
            int pageSize = 15;
            int pageNum = page ?? 1;
            var query = from c in data.categories select c;
            var booksold = from b in data.Books
                           join ol in data.order_lists on b.id equals ol.id_book
                           group new { b, ol } by new { b.id } into g
                           select new BookSold
                           {
                               Book_id = g.Key.id,
                               Book_qty_sold = g.Sum(n => Convert.ToInt32(n.ol.amount))
                           };
            ViewBag.ListCategory = query;
            ViewBag.BookSold = booksold;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

        [HttpPost]
        public ActionResult Index(int? page, string search)
        {
            if (page == null) page = 1;
            var all_sach = (from s in data.Books where s.title.Contains(search) || s.category.name.Contains(search) select s).OrderBy(m => m.id);
            int pageSize = 15;
            int pageNum = page ?? 1;
            var query = from c in data.categories select c;
            var booksold = from b in data.Books
                           join ol in data.order_lists on b.id equals ol.id_book
                           group new { b, ol } by new { b.id } into g
                           select new BookSold
                           {
                               Book_id = g.Key.id,
                               Book_qty_sold = g.Sum(n => Convert.ToInt32(n.ol.amount))
                           };
            ViewBag.ListCategory = query;
            ViewBag.BookSold = booksold;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }


        public ActionResult Detail(int id)
        {
            var D_sach = data.Books.Where(m => m.id == id).First();
            return View(D_sach);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Book s)
        {
            var E_tenloai = Convert.ToInt32(collection["category_id"]);
            var E_tensach = collection["title"];
            var E_giaban = Convert.ToDouble(collection["price"]);
            var E_soluongton = Convert.ToInt32(collection["qty"]);
            var E_hinh = collection["image_path"];
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.category_id = E_tenloai;
                s.title = E_tensach.ToString();
                s.price = E_giaban;
                s.qty = E_soluongton;
                s.image_path = E_hinh.ToString();
                data.Books.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListBook");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_sach = data.Books.First(m => m.id == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.Books.First(m => m.id == id);
            var E_tensach = collection["title"];
            var E_hinh = collection["image_path"];
            var E_giaban = Convert.ToDouble(collection["price"]);
            var E_soluongton = Convert.ToInt32(collection["qty"]);
            E_sach.id = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.title = E_tensach;
                E_sach.image_path = E_hinh;
                E_sach.price = E_giaban;
                E_sach.qty = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("ListBook");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(int id)
        {
            var D_sach = data.Books.First(m => m.id == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.Books.Where(m => m.id == id).First();
            data.Books.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("ListBook");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Asset/admin/img/" + file.FileName));
            return "/Asset/admin/img/" + file.FileName;
        }


        public ActionResult BookInCate(int? page, int id)
        {
            if (page == null) page = 1;
            var all_sach = (from s in data.Books where s.category_id == id select s).OrderBy(m => m.id);
            int pageSize = 15;
            int pageNum = page ?? 1;
            var query = from c in data.categories select c;
            var booksold = from b in data.Books
                           join ol in data.order_lists on b.id equals ol.id_book
                           group new { b, ol } by new { b.id } into g
                           select new BookSold
                           {
                               Book_id = g.Key.id,
                               Book_qty_sold = g.Sum(n => Convert.ToInt32(n.ol.amount))
                           };
            ViewBag.ListCategory = query;
            ViewBag.IdCategory = id;
            ViewBag.BookSold = booksold;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

        //public ActionResult BookInSale(int? page)
        //{
        //    if (page == null) page = 1;
        //    var all_sach = (from s in data.Books select s).OrderBy(m => m.id);
        //    int pageSize = 15;
        //    int pageNum = page ?? 1;
        //    var query = from c in data.categories select c;
        //    var booksold = from b in data.Books
        //                   join ol in data.order_lists on b.id equals ol.id_book
        //                   group new { b, ol } by new { b.id } into g
        //                   select new BookSold
        //                   {
        //                       Book_id = g.Key.id,
        //                       Book_qty_sold = g.Sum(n => Convert.ToInt32(n.ol.amount))
        //                   };
        //    var booksale = from b in data.Books
        //                   join ol in data.order_lists on b.id equals ol.id_book
        //                   group new { b, ol } by new { b.id, b.title, b.price, b.image_path} into g
        //                   orderby g.Sum(n => Convert.ToInt32(n.ol.amount)) descending
        //                   select new BookSold
        //                   {
        //                       Book_id = g.Key.id,
        //                       Book_image = g.Key.image_path,
        //                       Book_name = g.Key.title,
        //                       Book_price = Convert.ToDouble(g.Key.price),
        //                       Book_qty_sold = g.Sum(n => Convert.ToInt32(n.ol.amount))
        //                   };
        //    ViewBag.ListCategory = query;
        //    ViewBag.BookSold = booksold;
        //    ViewBag.BookInSale = booksale;
        //    return View(all_sach.ToPagedList(pageNum, pageSize));
        //}

    }
}