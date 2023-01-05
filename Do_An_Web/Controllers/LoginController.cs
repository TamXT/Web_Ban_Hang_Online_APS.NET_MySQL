using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;

namespace Do_An_Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost ]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {

            // doc thog tin tai khoan tu data base thong qua data model de xet co dung tai khoan va mk khong
            TaiKhoan ttdn = new ShopOnline_Demo()
                .TaiKhoan.Where(x => x.taiKhoan1.Equals(Acc.ToLower().Trim()) && x.matKhau.Equals(Pass))
                .FirstOrDefault<TaiKhoan>();
            bool isAuthenic = ttdn != null && ttdn.taiKhoan1.Equals(Acc.ToLower().Trim()) && ttdn.matKhau.Equals(Pass);
            if (isAuthenic)
            { 
                Session["TtDangNhap"] = ttdn;
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("~/Login");
        }
        
        
    }
}