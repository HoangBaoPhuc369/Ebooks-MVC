﻿using Ebooks.Models;
using Ebooks.MoMoPayment;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book = Ebooks.Models.Book;

namespace Ebooks.Controllers
{
    public class CartController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();

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
        public ActionResult Add2Cart(string addcart, string buynow, int id, string strUrl, FormCollection collection)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.Find(n => n.book_id == id);
            if (sanpham == null && addcart != null)
            {
                sanpham = new Cart(id);
                sanpham.qty = int.Parse(collection["txtSoLg"].ToString());
                lstGiohang.Add(sanpham);
                return Redirect(strUrl);
            }
            else if (sanpham == null && buynow != null)
            {
                sanpham = new Cart(id);
                sanpham.qty = int.Parse(collection["txtSoLg"].ToString());
                lstGiohang.Add(sanpham);
                return RedirectToAction("Cart");
            }
            else if (sanpham != null && buynow != null)
            {
                sanpham.qty = sanpham.qty + int.Parse(collection["txtSoLg"].ToString());
                return RedirectToAction("Cart");
            }
            else
            {
                sanpham.qty = sanpham.qty + int.Parse(collection["txtSoLg"].ToString());
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

        public ActionResult DeleteCartInIcon(int id, string strUrl)
        {
            List<Cart> lstGiohang = GetCarts();
            Cart sanpham = lstGiohang.SingleOrDefault(n => n.book_id == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.book_id == id);
                return Redirect(strUrl);
            }
            return Redirect(strUrl);
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

        [HttpGet]
        public ActionResult Order()
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Books");
            }
            List<Cart> lstCart = GetCarts();
            ViewBag.TotalQty = TotalQty();
            ViewBag.TotalPrice = TotalPrice();
            ViewBag.TotalBook = TotalBook();
            return View(lstCart);
        }

        public ActionResult Order(FormCollection collection)
        {
            order dh = new order();
            customer kh = (customer)Session["username"];
            Book s = new Book();

            List<Cart> gh = GetCarts();
            //var date_delivery = String.Format("{0:MM/dd/yyyy}", collection["date_delivery"]);
            dh.id_customer = kh.id;
            dh.date_create = DateTime.Now;
            //dh.date_delivery = DateTime.Parse(date_delivery);
            dh.status = false;
            dh.paid = false;

            data.orders.InsertOnSubmit(dh);
            data.SubmitChanges();
            foreach (var item in gh)
            {
                order_list ctdh = new order_list();
                ctdh.id_order = dh.id;
                ctdh.id_book = item.book_id;
                ctdh.amount = item.qty;
                ctdh.unit_price = (double)item.total;
                s = data.Books.Single(n => n.id == item.book_id);
                s.qty -= ctdh.amount;
                data.SubmitChanges();
               
                data.order_lists.InsertOnSubmit(ctdh);
            } 
            data.SubmitChanges();
            Session["Cart"] = null;
            return RedirectToAction("ConfirmOrder", "Cart");
        }

        public ActionResult ConfirmOrder()
        {
            customer kh = (customer)Session["username"];
            var query =  from o in data.orders
                         join ol in data.order_lists on o.id equals ol.id_order
                         join b in data.Books on ol.id_book equals b.id
                         join ca in data.categories on b.category_id equals ca.id
                         where o.id_customer == kh.id
                         select new CustomerOrder 
                         {
                             Book_id = b.id,
                             BookImage = b.image_path,
                             BookName = b.title,
                             BookAmount = (int)ol.amount,
                             BookCate = ca.name,
                             BookUnitPrice = (double)b.price,
                             TotalPriceBook = (double)ol.unit_price,
                             Book_order_status = Convert.ToByte(o.status),
                         };
            ViewBag.OrderCustomer = query;
            return View();
        }

        public ActionResult RegisterInfo()
        {
            return Order();
        }

        //Ham Post nhan du lieu tu trang Register va thuc hien viec tao moi du lieu
        [HttpPost]
        public ActionResult RegisterInfo(FormCollection collection)
        {
            customer kh = (customer)Session["username"];
            var D_customer = data.customers.Where(m => m.id == kh.id).First();
            if (D_customer != null)
            {
                //Gan cac gia tri nguoi dung nhap lieu cac bien
                var Name = collection["Name"];
                var Contact = collection["Contact"];
                var Address = collection["Address"];
                if (String.IsNullOrEmpty(Name))
                {
                    ViewData["err1"] = "Bạn cần nhập họ và tên";
                }
                else if (String.IsNullOrEmpty(Contact))
                {
                    ViewData["err2"] = "Bạn cần nhập số điện thoại";
                }
                else if (String.IsNullOrEmpty(Address))
                {
                    ViewData["err3"] = "Bạn cần nhập địa chỉ";
                }
                else
                {
                    //Gan gia tri cho doi tuong duoc tao moi (customer)
                    kh.name = Name;
                    kh.contact = Contact;
                    kh.address = Address;
                    D_customer.name = Name;
                    D_customer.contact = Contact;
                    D_customer.address = Address;
                    UpdateModel(D_customer);
                    data.SubmitChanges();
                    return RedirectToAction("Order");
                }
            }
            return RedirectToAction("Order");
        }

        public ActionResult OrderMoMo()
        {
            order dh = new order();
            customer kh = (customer)Session["username"];
            Book s = new Book();
            List<Cart> gh = GetCarts();
            dh.id_customer = kh.id;
            dh.date_create = DateTime.Now;
            dh.status = false;
            dh.paid = false;

            data.orders.InsertOnSubmit(dh);
            data.SubmitChanges();
            foreach (var item in gh)
            {
                order_list ctdh = new order_list();
                ctdh.id_order = dh.id;
                ctdh.id_book = item.book_id;
                ctdh.amount = item.qty;
                ctdh.unit_price = (double)item.total;
                s = data.Books.Single(n => n.id == item.book_id);
                s.qty -= ctdh.amount;
                data.SubmitChanges();

                data.order_lists.InsertOnSubmit(ctdh);
            }
            data.SubmitChanges();
            Session["Cart"] = null;
            return RedirectToAction("ConfirmOrder", "Cart");
        }


        public ActionResult Payment()
        {
            List<Cart> gh = GetCarts();
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMO7EVQ20220329";
            string accessKey = "2UlpvafBHM2XkWkD";
            string serectkey = "2NcYVTZQjNjZ62VnxQlDPApmsUwpS6u0";
            string orderInfo = "Thanh Toán Sách";
            string returnUrl = "https://localhost:44358/Cart/OrderMoMo";
            string notifyurl = " http://c40f-2405-4802-91b8-6d70-ccca-2655-a56d-e6f5.ngrok.io/Cart/Order"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = gh.Sum(n => n.total).ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }


    }


}