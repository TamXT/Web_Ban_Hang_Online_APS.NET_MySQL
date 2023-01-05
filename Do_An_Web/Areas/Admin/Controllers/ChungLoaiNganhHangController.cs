using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_Web.Models;

namespace Do_An_Web.Areas.Admin.Controllers
{
    public class ChungLoaiNganhHangController : Controller
    {
        private static bool isUpdate = false;
        // GET: Admin/ChungLoaiNganhHang
        [HttpGet]
        public ActionResult Index()
        {
            List<LoaiSP> l = new ShopOnline_Demo().LoaiSP.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["DsLoai"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            ShopOnline_Demo db = new ShopOnline_Demo();
            //Add loai sp   
            if(!isUpdate)
                db.LoaiSP.Add(x);
            else
            {
                LoaiSP y = db.LoaiSP.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }
            db.SaveChanges();
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<LoaiSP> l = db.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            ViewData["DsLoai"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(String maLoai)
        {
            ShopOnline_Demo db = new ShopOnline_Demo();
            int ma = int.Parse(maLoai);
            //b1:--Find loaiSP object in Data model by maloai.....
            LoaiSP x = db.LoaiSP.Find(ma);
            //b2:--remove loaisp
            db.LoaiSP.Remove(x);
            //b3:--update to database
            db.SaveChanges();
            //b4:--updtae data on View
            ViewData["DsLoai"] = db.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");
        }
        public ActionResult Update(String maLoaiCanSua)
        {
            ShopOnline_Demo db = new ShopOnline_Demo();
            int ma = int.Parse(maLoaiCanSua);
            //b1:--Find loaiSP object in Data model by maloai.....
            LoaiSP x = db.LoaiSP.Find(ma);
            isUpdate = true;
            ViewData["DsLoai"] = db.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("index", x);
        }
    }
}