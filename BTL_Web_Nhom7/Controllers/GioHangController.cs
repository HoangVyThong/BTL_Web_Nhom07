using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BTL_Web_Nhom7.Controllers
{
    public class GioHangController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public const string CARTKEY = "GioHang";

        // Lấy cart từ Session (danh sách CartItem)
        List<GioHang> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<GioHang>>(jsoncart);
            }
            return new List<GioHang>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<GioHang> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public IActionResult ThemGioHang(string MaThietBi, IFormCollection f)
        {
            var session = HttpContext.Session;
            var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
            if (sanpham == null)
            {
                return BadRequest();
            }
            List<GioHang> gioHangs = GetCartItems();
            var gioHang = gioHangs.Find(n => n.MaThietBi == MaThietBi);
            if (gioHang == null)
            {
                gioHang = new GioHang(MaThietBi);
                int gia = (int)sanpham.GiaBan;
                if (gia > 0)
                    gioHang.DonGia = gia;
                gioHang.SoLuong = int.Parse(f["Soluong"].ToString());
                if (gioHang.SoLuong > 0)
                {
                    gioHangs.Add(gioHang);
                    SaveCartSession(gioHangs);
                }
                    

                //return Redirect("/GioHang/GioHang");
            }
            else
            {
                int soluong = int.Parse(f["Soluong"].ToString());
                if (sanpham.SoLuong + soluong < gioHang.SoLuong)
                {
                    gioHang.SoLuong += soluong;
                    
                    SaveCartSession(gioHangs);
                }

                else
                {
                    gioHang.SoLuong = (int)sanpham.SoLuong;
                    SaveCartSession(gioHangs);
                }

            }
            
            return Redirect("/Giohang/GioHang");

        }
        public IActionResult CapNhapSoLuong(string MaThietBi, IFormCollection f)
        {
            var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
            if (sanpham == null)
            {
                BadRequest();
            }
            List<GioHang> listGioHang = GetCartItems();
            GioHang sp = listGioHang.Single(n => n.MaThietBi == MaThietBi);
            if (sp != null)
            {
                sp.SoLuong = int.Parse(f["Soluong"].ToString());
                if (int.Parse(f["Soluong"].ToString()) <= 0)
                {
                    Xoa(MaThietBi);
                }
                SaveCartSession(listGioHang);
            }
            return RedirectToAction("GioHang");
        }
        public IActionResult Xoa(string MaThietBi)
        {
            //kiểm tra mã sản phẩm
            MaThietBi = MaThietBi.Split(')')[0];
            var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = GetCartItems();
            GioHang sp = lstGioHang.Single(n => n.MaThietBi == MaThietBi);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.MaThietBi == MaThietBi);
                SaveCartSession(lstGioHang);
            }
            if (lstGioHang.Count == 0)
            {
                RedirectToAction("TrangChu", "BanHang");
            }
            return RedirectToAction("GioHang");
        }

        public IActionResult GioHang()
        {
            
            ViewBag.TongTien = TongTien();
            ViewBag.SoLuong = TongSoLuong();
            
            return View(GetCartItems());
        }
        public int TongSoLuong()
        {
            int t = 0;
            List<GioHang> listGioHang = GetCartItems();
            t = listGioHang.Count;
            return t;
        }
        public double TongTien()
        {
            double t = 0;
            List<GioHang> listGioHang = GetCartItems();
            t = (double)listGioHang.Sum(n => n.ThanhTien);
            return t;
        }
        public ActionResult SuaGioHang()
        {
            return View();
        }


        #region Đặt hàng
        [HttpGet]
        public IActionResult ThanhToan()
        {
            if (HttpContext.Session.GetString("GioHang") == null)
            {
                return RedirectToAction("TrangChu", "BanHang");
            }
            List<GioHang> gioHangs = GetCartItems();

            ViewBag.TongTien = TongTien();
            ViewBag.SoLuong = TongSoLuong();
            return View(gioHangs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThanhToan(IFormCollection f)
        {
            List<GioHang> gioHangs = GetCartItems();
            
            foreach (var item in gioHangs)
            {
                var t = db.ThietBiYtes.SingleOrDefault(n => n.MaThietBi == item.MaThietBi);
                if (t.SoLuong < item.SoLuong)
                {
                    ViewBag.Loi = item.TenThietBi + " không đủ!";
                    Xoa(item.MaThietBi);
                    return View(gioHangs);
                }
            }
            //lưu thông tin vào hóa đơn bán
            HoaDonBan hd = new HoaDonBan();
            string name = f["Name"].ToString();
            string phone = f["Phone"].ToString();
            string address = f["Address"].ToString();
            string email = f["Email"].ToString();
            int check = db.KhachHangs.Where(n => n.TenKh == name && n.Email == email).Count();
            KhachHang khachHang = new KhachHang();
            if (check == 0)
            {
                int Sl = db.KhachHangs.ToList().Count();
                string MaKH = "KH_" + (Sl+2).ToString();
                khachHang.MaKh = MaKH;
                khachHang.TenKh = name;
                khachHang.Email = email;
                khachHang.DienThoai = phone;
                khachHang.DiaChi = address;
                
                db.KhachHangs.Add(khachHang);
            }
            else
            {
                khachHang = db.KhachHangs.SingleOrDefault(n => n.TenKh == name && n.Email == email && n.DienThoai == phone);
            }
            hd.MaKh = khachHang.MaKh;
            hd.NgayLap = DateTime.Now;
            int sl1 = (db.HoaDonBans.ToList().Count() + 2);
            hd.SoHdb = "HDB_" + sl1.ToString();

            db.HoaDonBans.Add(hd);
            db.SaveChanges();
            foreach (var item in gioHangs)
            {
                ChiTietHdb cthd = new ChiTietHdb();
                cthd.SoHdb = hd.SoHdb;
                cthd.MaThietBi = item.MaThietBi;
                cthd.SoLuong = item.SoLuong;
                cthd.ThanhTien = (decimal?)item.ThanhTien;
                db.ThietBiYtes.Find(item.MaThietBi).SoLuong -= item.SoLuong;
                db.ChiTietHdbs.Add(cthd);
            }
            HttpContext.Session.Remove("GioHang");
            db.SaveChanges();
            return RedirectToAction("TrangChu", "BanHang");
        }
        #endregion  
    }
}