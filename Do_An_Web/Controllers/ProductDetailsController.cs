using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;

namespace Do_An_Web.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index(string maSanPham)
        {
            // dua vao LINQ lay doi tuong san pham tu data model
            ShopOnline_Demo db = new ShopOnline_Demo();
            SanPham x = db.SanPham.Where(sp => sp.maSP.Equals(maSanPham)).First<SanPham>();
           
            // lam sao de dua vao View [o day la controller]
            ViewData["SpCanXem"] = x;
            return View();
        }
    }
}