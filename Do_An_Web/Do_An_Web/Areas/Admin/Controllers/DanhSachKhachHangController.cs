using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_Web.Areas.Admin.Controllers
{
    public class DanhSachKhachHangController : Controller
    {
        // GET: Admin/DanhSachKhachHang
        public ActionResult Index()
        {
            return View();
        }
    }
}