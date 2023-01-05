using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;
namespace Do_An_Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            CartShop gh = Session["GioHang"] as CartShop;
            ViewData["Cart"] = gh;

            return View("Index");
        }
        public ActionResult Increase(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return View("Index");
        }
        public ActionResult RemoveItem(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.deleteItem(maSP);
            Session["GioHang"] = gh;
            return View("Index");
        }

    }
}