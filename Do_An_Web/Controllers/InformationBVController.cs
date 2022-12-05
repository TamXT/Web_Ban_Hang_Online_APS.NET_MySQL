using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;

namespace Do_An_Web.Controllers
{
    public class InformationBVController : Controller
    {
        // GET: InformationBV
        public ActionResult Index(string maBaiViet)
        {
            // dua vao LINQ lay doi tuong san pham tu data model
            ShopOnline_Demo db = new ShopOnline_Demo();
            BaiViet x = db.BaiViet.Where(sp => sp.maBV.Equals(maBaiViet)).First<BaiViet>();

            // lam sao de dua vao View [o day la controller]
            ViewData["SpCanXem"] = x;
            return View();
        }
    }
}