using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using X.PagedList;

namespace BTL_Web_Nhom7.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BtlWebContext db = new BtlWebContext();
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Dangnhap()
        {
            if (HttpContext.Session.GetString("Name") != null)
            {
                HttpContext.Session.SetString("Name", null);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dangnhap(FormCollection f)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                String sTaiKhoan = f["name"].ToString();
                String sMatKhau = GetMd5Hash(md5Hash, f["password"].ToString());
                var NguoiDung = from p in db.TaiKhoans
                                where p.UserName == sTaiKhoan && p.Password == sMatKhau
                                select p;
                if (NguoiDung.Count() == 0)
                {
                    ViewBag.Thongbao = "Tài khoản hoặc mật khẩu sai";
                    return View();
                }
                else
                {
                    string Id = db.TaiKhoans.SingleOrDefault(n => n.UserName == sTaiKhoan).Id;
                    string name = db.ChuQuanLies.SingleOrDefault(n => n.Id == Id).Ten.Split().LastOrDefault();
                    HttpContext.Session.SetString("Name",name);
                    return RedirectToAction("TrangChu", "Admin");
                }
            }
        }
        [Authentication]
        public IActionResult TrangChu()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Dangnhap", "Admin");
            }
            else
            {
                HttpContext.Session.SetString("Name", HttpContext.Session.GetString("Name"));
            }
            return View();
        }
        [Authentication]
        public IActionResult HoaDon(int? page)
        {
            var listHoaDons = db.HoaDonBans.ToList();
            int pagesize = 20;
            int pagenumber = (page ?? 1) > pagesize ? (page ?? 1) : 1;
            if (listHoaDons.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy hóa đơn";
                return View(db.HoaDonBans.OrderBy(n => n.SoHdb).ToPagedList(pagenumber, pagesize));
            }
            return View(listHoaDons.OrderByDescending(n => n.NgayLap).ToPagedList(pagenumber, pagesize));
        }
        [Authentication]
        public PartialViewResult PartialHoaDon(string SoHD = "HDB_1")
        {
            if (SoHD == null)
            {
                return PartialView();
            }
            var hoaDonBan = db.HoaDonBans.SingleOrDefault(n => n.SoHdb == SoHD);
            if (hoaDonBan == null)
            {
                return PartialView();
            }
            var chiTietHDBs = db.ChiTietHdbs.Where(n => n.SoHdb == SoHD).ToList();
            Decimal? TongTien = 0;
            foreach (var t in chiTietHDBs)
            {
                TongTien += t.ThanhTien;
            }
            ViewBag.TongTien = TongTien;
            return PartialView(hoaDonBan);
        }
        [Authentication]
        public IActionResult ChiTietHoaDon(string SoHD)
        {
            var s = from p in db.ChiTietHdbs 
                    join q in db.ThietBiYtes on p.MaThietBi equals q.MaThietBi
                    where p.SoHdb == SoHD
                    select new
                    {
                        SoHDB = p.SoHdb,
                        TenThietBi = q.TenThietBi,
                        AnhThietBi = q.Anh,
                        SoLuong = q.SoLuong,
                        GiaBan = q.GiaBan,
                        ThanhTien = p.ThanhTien
                    };
            return View(s);
            //return Json(s, JsonRequestBehavior.AllowGet);
        }
        [Authentication]
        [HttpPost]
        public IActionResult Danhsach(FormCollection f, int? page)
        {
            var t = new List<LoaiThietBi>();
            foreach (var i in db.LoaiThietBis.ToList().OrderBy(n => n.TenLoai))
            {
                t.Add(i);
            }
            ViewBag.MaLoai = new SelectList(t, "MaLoai", "TenLoai");
            string MaLoai = f["MaLoai"];
            var listThietBi = db.ThietBiYtes.Where(n => n.MaLoai == MaLoai).ToList();
            int pagesize = 20;
            int pagenumber = (page ?? 1) > pagesize ? (page ?? 1) : 1;
            if (listThietBi.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.ThietBiYtes.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.Loai = db.LoaiThietBis.SingleOrDefault(n => n.MaLoai == MaLoai).TenLoai;
            ViewBag.ThongBao = "Đã tìm thấy" + listThietBi.Count + "sản phẩm";
            return View(listThietBi.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
        }
        [Authentication]
        [HttpGet]
        public IActionResult Danhsach(int? page, string MaLoai)
        {
           var t = new List<LoaiThietBi>();
            foreach (var i in db.LoaiThietBis.ToList().OrderBy(n => n.TenLoai))
            {
                t.Add(i);
            }
            ViewBag.MaLoai = new SelectList(t, "MaLoai", "TenLoai");
            List<ThietBiYte> listThietBi = db.ThietBiYtes.Where(n => n.MaLoai == MaLoai).ToList();
            int pagesize = 20;
            int pagenumber = (page ?? 1) > pagesize ? (page ?? 1) : 1;
            if (listThietBi.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.ThietBiYtes.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.Loai = db.LoaiThietBis.SingleOrDefault(n => n.MaLoai == MaLoai).TenLoai;
            ViewBag.ThongBao = "Đã tìm thấy" + listThietBi.Count + "sản phẩm";
            return View(listThietBi.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
        }
        [Authentication]
        public IActionResult Sanphamtungloai(String MaLoai)
        {
            var thietBis = from p in db.ThietBiYtes
                           join q in db.LoaiThietBis on p.MaLoai equals q.MaLoai
                           where p.MaLoai == MaLoai
                           select new
                           {
                               MaThietBi = p.MaThietBi,
                               TenThietBi = p.TenThietBi,
                               GiaBan = p.GiaBan,
                               GioiThieu = p.GioiThieu,
                               TenLoai = q.TenLoai,
                               Anh = p.Anh
                           };
            thietBis.OrderBy(x => x.TenThietBi).ToList();
            return View(thietBis);
            //return Json(Thietbis, JsonRequestBehavior.AllowGet);
        }
        [Authentication]
        public PartialViewResult PartialOpsitionLoai()
        {
            return PartialView(db.LoaiThietBis.ToList());
        }
        public PartialViewResult PartialDanhSach(String MaThietbi = "TB11")
        {
            var t = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietbi);
            if (t == null)
            {
                Response.StatusCode = 404;
                return PartialView();
            }
            var loai = db.LoaiThietBis.SingleOrDefault(n => n.MaLoai == t.MaLoai);
            ViewBag.LoaiThietBi = loai.TenLoai;
            return PartialView(t);
        }
        [Authentication]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiThietBis.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaHang = new SelectList(db.HangThietBis.ToList().OrderBy(n => n.Ten), "MaHang", "Ten");
            int MaThietBi = db.ThietBiYtes.ToList().Count + 1;
            while (true)
            {
                if (db.ThietBiYtes.SingleOrDefault(n => n.MaThietBi == ("TB" + MaThietBi.ToString())) == null)
                {
                    ViewBag.MaThietBi = "TB" + MaThietBi.ToString();
                    break;
                }
                MaThietBi++;
            }
            return View();
        }
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(ThietBiYte thietbi)
        {
            if (ModelState.IsValid)
            {
                thietbi.TongSoSao = 0;
                thietbi.TongSoDanhGia = 0;
                db.ThietBiYtes.Add(thietbi);
                db.SaveChanges();
                return RedirectToAction("TrangChu");
            }
            return View(thietbi);
        }
        [Authentication]
        [HttpGet]
        public ActionResult SuaSanPham(string MaSP = "1")
        {
            if (MaSP == null)
            {
                return BadRequest("Không tồn tại mã sản phẩm này");
            }
            var thietbi = db.ThietBiYtes.Find(MaSP);
            if (thietbi == null)
            {
                return NotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiThietBis.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaHang = new SelectList(db.HangThietBis.ToList().OrderBy(n => n.Ten), "MaHang", "Ten");

            return View(thietbi);
        }
        [Authentication]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham(ThietBiYte thietbi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thietbi).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("TrangChu");
        }
    }
}
