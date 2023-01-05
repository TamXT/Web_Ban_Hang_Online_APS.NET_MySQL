using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_Web.Models
{
    [Serializable]
    public class CartShop
    {
        public string MaKH { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public SortedList<string, CtDonHang> SanPhamDC { get; set; }

        public CartShop()
        {
            this.MaKH = "";
            this.TaiKhoan = "";
            this.NgayDat = DateTime.Now;
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.SanPhamDC = new SortedList<string, CtDonHang>();
        }
        public bool IsEmpty()
        {
            return SanPhamDC.Keys.Count == 0;
        }
        public void addItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                x.soLuong++;
                SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)] = x;
            }
            else
            {
                CtDonHang i = new CtDonHang();
                i.maSP = maSP;
                i.soLuong = 1;
                SanPham z = Common.GetProductById(maSP);
                i.giaBan = z.giaBan;
                i.giamGia = z.giamGia;
                SanPhamDC.Add(maSP, i);

            }
        }
        public void deleteItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                SanPhamDC.Remove(maSP);
            }
        }
        public void UpdateOneItem(CtDonHang x)
        {
            this.SanPhamDC.Remove(x.maSP);
            this.SanPhamDC.Add(x.maSP, x);
        }
        public void decrease(string maSP)
        {
            CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
            if (x.soLuong > 1)
            {
                x.soLuong--;
                SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)] = x;
            }
            else
            {
                deleteItem(maSP);
            }   
        }
        public long moneyOfOneItem(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia));
        }
        public long totalOfCartShop()
        {
            long kq = 0;
            foreach (CtDonHang i in SanPhamDC.Values)
                kq += moneyOfOneItem(i);
            return kq;
        }

        
    }
}