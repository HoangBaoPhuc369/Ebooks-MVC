using Ebooks.Areas.Admin.Models;
using Ebooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebooks.Controllers
{
    public class CartController : Controller
    {
        MyAdminDataDataContext data = new MyAdminDataDataContext();

        // GET: Cart
        public List<Cart> GetCarts()
        {
            List<Cart> lstGiohang = Session["Cart"] as List<Cart>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Cart>();
                Session["Cart"] = lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult Add2Cart(int id, string strUrl)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.Find(n => n.book_id == id);
            if (sanpham == null)
            {
                sanpham = new Cart(id);
                lstGiohang.Add(sanpham);
                return Redirect(strUrl);
            }
            else
            {
                sanpham.qty++;
                return Redirect(strUrl);
            }
        }

        private int TotalQty()
        {
            int tsl = 0;
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(n => n.qty);
            }
            return tsl;
        }

        private int TotalBook()
        {
            int tsl = 0;
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Count;
            }
            return tsl;
        }

        private double TotalPrice()
        {
            double tt = 0;
            List<Cart> lstGioHang = Session["Cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                tt = lstGioHang.Sum(n => n.total);
            }
            return tt;
        }

        public ActionResult Cart()
        {
            List<Cart> lstGiohang = GetCarts();
            ViewBag.TotalQty = TotalQty();
            ViewBag.TotalPrice = TotalPrice();
            ViewBag.TotalBook = TotalBook();
            return View(lstGiohang);
        }



        public ActionResult CartPartial()
        {
            List<Cart> lstItem = GetCarts();
            ViewBag.IsCart = lstItem.Count();
            ViewBag.lstItem = lstItem;
            ViewBag.TotalQty = TotalQty();
            ViewBag.TotalPrice = TotalPrice();
            ViewBag.TotalBook = TotalBook();
            return PartialView();
        }

        public ActionResult DeleteCart(int id)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.SingleOrDefault(n => n.book_id == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.book_id == id);
                return RedirectToAction("Cart");
            }
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCartInIcon(int id)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.SingleOrDefault(n => n.book_id == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.book_id == id);
                return RedirectToAction("Detail", "Books");
            }
            return RedirectToAction("Detail", "Books");
        }

        public ActionResult UpdateCart(int id, FormCollection collection)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.SingleOrDefault(n => n.book_id == id);
            if (sanpham != null)
            {
                sanpham.qty = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteAllCart()
        {
            List<Cart> lstGiohang = GetCarts();
            lstGiohang.Clear();
            return RedirectToAction("Cart");
        }
    }
}