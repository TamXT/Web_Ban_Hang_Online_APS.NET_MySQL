using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Do_An_Web.Models;
namespace Do_An_Web.Areas.Admin.Models
{
    public class ThuongDung
    {
        public static TaiKhoan GetTaiKhoanHH()
        {
            
            TaiKhoan kq = new TaiKhoan();
            kq = HttpContext.Current.Session["TtDangNhap"] as TaiKhoan;
            return kq;
        }
        public static string GetTenTaiKhoan()
        {
            return GetTaiKhoanHH().taiKhoan1;
        }
    }
}