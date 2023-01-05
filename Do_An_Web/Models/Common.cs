using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Do_An_Web.Models
{
    public class Common
    {
        static DbContext cn = new DbContext("name=ShopOnline_Demo");
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
        public static List<BaiViet> GetBaiViet(int n)
        {
            List<BaiViet> l = new List<BaiViet>();
            ShopOnline_Demo db = new ShopOnline_Demo();
            l = db.BaiViet.Where(m => m.daDuyet == true).OrderByDescending(bv => bv.ngayDang).Take(n).ToList<BaiViet>();
            return l;
            
        }
        public static SanPham GetProductById(string maSP)
        {

            DbContext cn = new DbContext("name=ShopOnline_Demo");
            
            return cn.Set<SanPham>().Find(maSP);
        }
        public static string getNameOfProductById(string maSP)
        {
            

            return cn.Set<SanPham>().Find(maSP).tenSP;
        }
        public static string getImageOfProductById(string maSP)
        {
           
            return cn.Set<SanPham>().Find(maSP).hinhDD;
        }
    }

}