using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BTL_Web_Nhom7.Controllers
{
    public class GioHangController : Controller
    //{
    //    BtlWebContext db = new BtlWebContext();

        

    //    public List<GioHang> LayGioHang()
    //    {
    //        var session = HttpContext.Session;
    //        var gioHangs = session.GetString("GioHang");
    //        if (gioHangs == null)
    //        {
    //            List<GioHang> tmp = new List<GioHang>();
    //            HttpContext.Session.SetString("GioHang", JsonConvert.SerializeObject(tmp));
    //        }
    //        gioHangs = session.GetString("GioHang");
    //        return JsonConvert.DeserializeObject<List<GioHang>>(gioHangs);
    //    }

    //    public ActionResult ThemGioHang(string MaThietBi, string strUrl, FormCollection f)
    //    {
    //        var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
    //        if (sanpham == null)
    //        {
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<GioHang> gioHangs = LayGioHang();
    //        var gioHang = gioHangs.Find(n => n.MaThietBi == MaThietBi);
    //        if (gioHang == null)
    //        {
    //            gioHang = new GioHang(MaThietBi);
    //            int gia = (int)sanpham.GiaBan;
    //            if (gia > 0)
    //                gioHang.DonGia = gia;
    //            gioHang.SoLuong = int.Parse(f["Soluong"].ToString());
    //            if (gioHang.SoLuong > 0)
    //                gioHangs.Add(gioHang);
    //            return Redirect(strUrl);
    //        }
    //        else
    //        {
    //            int soluong = int.Parse(f["Soluong"].ToString());
    //            if (sanpham.SoLuong + soluong < gioHang.SoLuong)
    //                gioHang.SoLuong += soluong;
    //            else
    //                gioHang.SoLuong = (int)sanpham.SoLuong;
    //            return Redirect(strUrl);
    //        }

    //    }
    //    public ActionResult CapNhapSoLuong(string MaThietBi, FormCollection f)
    //    {
    //        var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
    //        if (sanpham == null)
    //        {
                
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<GioHang> listGioHang = LayGioHang();
    //        GioHang sp = listGioHang.Single(n => n.MaThietBi == MaThietBi);
    //        if (sp != null)
    //        {
    //            sp.SoLuong = int.Parse(f["Soluong"].ToString());
    //            if (int.Parse(f["Soluong"].ToString()) <= 0)
    //            {
    //                Xoa(MaThietBi);
    //            }
    //        }
    //        return RedirectToAction("GioHang");
    //    }
    //    public ActionResult Xoa(string MaThietBi)
    //    {
    //        //kiểm tra mã sản phẩm
    //        MaThietBi = MaThietBi.Split(')')[0];
    //        var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
    //        if (sanpham == null)
    //        {
    //            Response.StatusCode = 404;
    //            return null;
    //        }
    //        List<GioHang> lstGioHang = LayGioHang();
    //        GioHang sp = lstGioHang.Single(n => n.MaThietBi == MaThietBi);
    //        if (sp != null)
    //        { lstGioHang.RemoveAll(n => n.MaThietBi == MaThietBi); }
    //        if (lstGioHang.Count == 0)
    //        { RedirectToAction("TrangChu", "BanHang"); }
    //        return RedirectToAction("GioHang");
    //    }

    //    public IActionResult GioHang()
    //    {
    //        if (HttpContext.Session.GetString("GioHang") == null)
    //        {
    //            return RedirectToAction("TrangChu", "BanHang");
    //        }
    //        var gioHangs = HttpContext.Session.GetString("GioHang");
    //        ViewBag.TongTien = TongTien();
    //        ViewBag.SoLuong = TongSoLuong();
    //        return View(JsonConvert.DeserializeObject<List<GioHang>>(gioHangs));
    //    }
    //    public int TongSoLuong()
    //    {
    //        int t = 0;
    //        List<GioHang> listGioHang = LayGioHang();
    //        t = listGioHang.Count;
    //        return t;
    //    }
    //    public double TongTien()
    //    {
    //        double t = 0;
    //        List<GioHang> listGioHang = LayGioHang();
    //        t = (double)listGioHang.Sum(n => n.ThanhTien);
    //        return t;
    //    }
    //    public ActionResult GioHangPartial()
    //    {
    //        if (TongSoLuong() != 0)
    //        {
    //            ViewBag.TongSoLuong = TongSoLuong();
    //        }
    //        return PartialView();
    //    }
    //    public ActionResult SuaGioHang()
    //    {
    //        return View();
    //    }


    //    #region Đặt hàng
    //    [HttpGet]
    //    public ActionResult ThanhToan()
    //    {
    //        if (HttpContext.Session.GetString("GioHang") == null)
    //        {
                
    //            return RedirectToAction("TrangChu", "BanHang");
    //        }
    //        var gioHangs = HttpContext.Session.GetString("GioHang");
    //        ViewBag.TongTien = TongTien();
    //        ViewBag.SoLuong = TongSoLuong();
    //        return View(JsonConvert.DeserializeObject<List<GioHang>>(gioHangs));
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult ThanhToan(FormCollection f)
    //    {
    //        if (HttpContext.Session.GetString("GioHang") == null)
    //        {
    //            return RedirectToAction("TrangChu", "BanHang");
    //        }
    //        List<GioHang> lstGioHang = LayGioHang();
    //        foreach (var item in lstGioHang)
    //        {
    //            var t = db.ThietBiYtes.SingleOrDefault(n => n.MaThietBi == item.MaThietBi);
    //            if (t.SoLuong < item.SoLuong)
    //            {
    //                ViewBag.Loi = item.TenThietBi + " không đủ!";
    //                Xoa(item.MaThietBi);
    //                return View(lstGioHang);
    //            }
    //        }
    //        //lưu thông tin vào hóa đơn bán
    //        HoaDonBan hd = new HoaDonBan();
    //        string name = f["Name"].ToString();
    //        string phone = f["Phone"].ToString();
    //        string address = f["Address"].ToString();
    //        string email = f["Email"].ToString();
    //        int check = db.KhachHangs.Where(n => n.TenKh == name && n.Email == email).Count();
    //        KhachHang khachHang = new KhachHang();
    //        if (check == 0)
    //        {
    //            int Sl = db.KhachHangs.ToList().Count > 0 ? db.KhachHangs.ToList().Count + 1 : 1;
    //            String MaKH = "KH_" + Sl.ToString();
    //            khachHang.MaKh = MaKH;
    //            khachHang.TenKh = name;
    //            khachHang.Email = email;
    //            khachHang.DienThoai = phone;
    //            khachHang.DiaChi = address;
    //            hd.MaKhNavigation = khachHang;
    //            db.KhachHangs.Add(khachHang);
    //        }
    //        else
    //        {
    //            khachHang = db.KhachHangs.SingleOrDefault(n => n.TenKh == name && n.Email == email && n.DienThoai == phone);
    //        }
    //        hd.MaKh = khachHang.MaKh;
    //        hd.NgayLap = DateTime.Now;
    //        hd.SoHdb = "HDB_" + ((db.HoaDonBans.ToList().Count() + 1) > 0 ? (db.HoaDonBans.ToList().Count() + 1) : 1).ToString();
    //        db.HoaDonBans.Add(hd);
    //        db.SaveChanges();
    //        foreach (var item in lstGioHang)
    //        {
    //            ChiTietHdb cthd = new ChiTietHdb();
    //            cthd.SoHdb = hd.SoHdb;
    //            cthd.MaThietBi = item.MaThietBi;
    //            cthd.SoLuong = item.SoLuong;
    //            cthd.ThanhTien = (decimal?)item.ThanhTien;
    //            db.ThietBiYtes.Find(item.MaThietBi).SoLuong -= item.SoLuong;
    //            db.ChiTietHdbs.Add(cthd);
    //        }
    //        HttpContext.Session.Remove("GioHang");
    //        db.SaveChanges();
    //        return RedirectToAction("TrangChu", "BanHang");
    //    }
    //    #endregion  
    //}
}
