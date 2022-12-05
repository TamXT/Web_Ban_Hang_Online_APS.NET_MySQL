using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Do_An_Web.Models
{
    public class Common
    {
        public static List<SanPham> GetSanPhams()
        {
            List<SanPham> l = new List<SanPham>();
            // khai báo đối tượng đại diện cho Database
            DbContext cn = new DbContext("name=ShopOnline_Demo");
            // lấy dữ liệu
            l = cn.Set<SanPham>().ToList<SanPham>();
            return l;
        }
        public static List<SanPham> GetSanPhamsByLoaiSPs(int maLoai)
        {
            List<SanPham> l = new List<SanPham>();
            // khai báo đối tượng đại diện cho Database
            DbContext cn = new DbContext("name=ShopOnline_Demo");
            // lấy dữ liệu
            l = cn.Set<SanPham>().Where(x=>x.maLoai == maLoai).ToList<SanPham>();
            return l;
        }
        public static List<LoaiSP> GetLoaiSPs()
        {
            return new DbContext ("name=ShopOnline_Demo").Set<LoaiSP>().ToList<LoaiSP>();
        }
        public static List<KhachHang> GetKhachHang()
        {
            return new DbContext("name=ShopOnline_Demo").Set<KhachHang>().ToList();
        }
        public static List<BaiViet> GetBaiViet()
        {
            return new DbContext("name=ShopOnline_Demo").Set<BaiViet>().ToList();
        }
    }
}