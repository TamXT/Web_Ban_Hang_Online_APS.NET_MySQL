using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;

namespace Do_An_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddToCart(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return View("Index");
        }

    }
}