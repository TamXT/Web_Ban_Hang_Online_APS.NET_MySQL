using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;
namespace Do_An_Web.Areas.Admin.Controllers
{
    public class DanhSachBaiVietController : Controller
    {
        // GET: Admin/DanhSachBaiViet
        // static collection-------------------------------------------------------------
        private static ShopOnline_Demo db = new ShopOnline_Demo();
        public static bool daDuyet;
        [HttpGet]
        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive !=null && IsActive.Equals("1");
            CapNhapGiaoDuLieuChoGiaoDien(daDuyet);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBaiViet)
        {
            BaiViet x = db.BaiViet.Find(maBaiViet);
            db.BaiViet.Remove(x);
            db.SaveChanges();

            //-- B1: Dùng lệnh để xóa bài viết dựa vào mã bài viết
            //-- B2: Cập nhập database
            //-- B3: Hiển thị lại danh sách khi xóa
            CapNhapGiaoDuLieuChoGiaoDien(true);
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            BaiViet x = db.BaiViet.Find(maBaiViet);
            x.daDuyet = (daDuyet? false: true);
            db.SaveChanges();

            //-- B1: Dùng lệnh để cấm bài viết dựa vào mã bài viết
            //-- B2: Cập nhập database
            //-- B3: Hiển thị lại danh sách khi xóa
            CapNhapGiaoDuLieuChoGiaoDien((bool)x.daDuyet);
            return View("Index");
        }
        /// <summary>
        /// Hàm phục vụ cho mục tiêu cập nhật dữ liệu cho View của controller này thông qua viewdata object
        /// </summary>
        private void CapNhapGiaoDuLieuChoGiaoDien(bool duyet)
        {
            List<BaiViet> l = db.BaiViet.Where(x=>x.daDuyet == duyet).ToList<BaiViet>();
            ViewData["DanhSachBV"] = l;
            ViewBag.tdCuaNut = daDuyet ? "Cấm Hiển Thị" : "Kiểm Duyệt Bài Viết";
        }
    }
}