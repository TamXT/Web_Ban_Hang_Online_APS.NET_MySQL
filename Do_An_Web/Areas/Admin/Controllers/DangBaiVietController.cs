using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;
using Do_An_Web.Areas.Admin.Models;
using System.IO;
namespace Do_An_Web.Areas.Admin.Controllers
 
{
    public class DangBaiVietController : Controller
    {
        // GET: Admin/DangBaiViet
        [HttpGet]
        public ActionResult Index()
        {
            BaiViet x = new BaiViet();
            x.ngayDang = DateTime.Now;
            x.soLanDoc = 0;
            x.taiKhoan = ThuongDung.GetTenTaiKhoan();
            ViewBag.ddhinh = "/Assets/Client/img/blog-3.jpg";
            return View(x);
        }
        
        public ActionResult Index(BaiViet x, HttpPostedFileBase hinhDaiDien)
        {
            try
            {
                x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.daDuyet = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = ThuongDung.GetTenTaiKhoan();
                x.soLanDoc = 0;
                x.loaiTin = "QC";
                if (hinhDaiDien != null)
                {
                    string virPath = "/Assets/Client/img/BaiViet/";
                    string PhyPath = Server.MapPath("~/" + virPath);
                    string ext = Path.GetExtension(hinhDaiDien.FileName);
                    string tenF = "HDD" + x.maBV + ext;
                    hinhDaiDien.SaveAs(PhyPath + tenF);
                    x.hinhDD = virPath + tenF;
                    ViewBag.ddhinh = x.hinhDD;
                }
                else
                
                    x.hinhDD = "";
                
                ShopOnline_Demo db = new ShopOnline_Demo();
                db.BaiViet.Add(x);
                db.SaveChanges();
                
                return RedirectToAction("Index", "DanhSachBaiViet", new {IsActive = 0});
            }
            catch(Exception e)
            {
                
                string s = e.Message;
            }
            return View(x);
        }
    }
}