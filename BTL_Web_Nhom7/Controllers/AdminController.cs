using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Models.Authentication;
using BTL_Web_Nhom7.Models.HoaDonModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using X.PagedList;

namespace BTL_Web_Nhom7.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BtlApiContext db = new BtlApiContext();
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

                RedirectToAction("TrangChu", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dangnhap(TaiKhoan taikhoan)
        {

            if (HttpContext.Session.GetString("TenTaiKhoan") == null)
            {
                var u = db.TaiKhoans.Where(x => x.TenTaiKhoan.Equals(taikhoan.TenTaiKhoan) && x.Password.Equals(taikhoan.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("TenTaiKhoan", u.TenTaiKhoan.ToString());
                    if (u.MaLoaiTaiKhoan == 1)
                    {
                        return RedirectToAction("TrangChu", "BanHang");
                    }
                    else
                    {
                        return RedirectToAction("TrangChu", "Admin");
                    }


                }

            }
            return View();

        }

        //public IActionResult LoginFacebook()
        //{
        //    return View();
        //}

        //public IActionResult LoginGoogle()
        //{
        //    return View();
        //}
        //[Authentication]
        public IActionResult TrangChu()
        {
            //if (HttpContext.Session.GetString("Name") == null)
            //{
            //    return RedirectToAction("Dangnhap", "Admin");
            //}
            //else
            //{
            //    HttpContext.Session.SetString("Name", HttpContext.Session.GetString("Name"));
            //}
            return View();
        }
        //[Authentication]
        public IActionResult HoaDon(int? page)
        {
            //sql: select ChiTietHDB.SoHDB,TenKH, DienThoai, DiaChi,NgayLap,SUM(ThanhTien) as ThanhTien from ChiTietHDB join HoaDonBan on ChiTietHDB.SoHDB = HoaDonBan.SoHDB join KhachHang on KhachHang.MaKH = HoaDonBan.MaKH
            //group by ChiTietHDB.SoHDB,TenKH,DienThoai, DiaChi, NgayLap
            var result = (from c in db.ChiTietHdbs
                          join h in db.HoaDonBans on c.SoHdb equals h.SoHdb
                          join kh in db.KhachHangs on h.MaKh equals kh.MaKh
                          group new { c, h, kh } by new
                          {
                              c.SoHdb,
                              kh.TenKh,
                              kh.DienThoai,
                              kh.DiaChi,
                              h.NgayLap
                          } into g
                          select new HoaDonDTO
                          {
                              SoHdb = g.Key.SoHdb,
                              TenKh = g.Key.TenKh,
                              DienThoai = g.Key.DienThoai,
                              DiaChi = g.Key.DiaChi,
                              NgayLap = g.Key.NgayLap,
                              ThanhTien = g.Sum(x => x.c.ThanhTien)
                          }).ToList();
            int pagesize = 20;
            int pagenumber = (page ?? 1) > pagesize ? (page ?? 1) : 1;
            if (result.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy hóa đơn";
                return View(db.HoaDonBans.OrderBy(n => n.SoHdb).ToPagedList(pagenumber, pagesize));
            }
            return View(result.OrderByDescending(n => n.NgayLap).ToPagedList(pagenumber, pagesize));
        }
        
        [HttpPost]
        public IActionResult Danhsach(IFormCollection f, int? page)
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
        }
        //[Authentication]
        //public PartialViewResult PartialOpsitionLoai()
        //{
        //    return PartialView(db.LoaiThietBis.ToList());
        //}
        //public PartialViewResult PartialDanhSach(String MaThietbi = "TB11")
        //{
        //    var t = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietbi);
        //    if (t == null)
        //    {
        //        Response.StatusCode = 404;
        //        return PartialView();
        //    }
        //    var loai = db.LoaiThietBis.SingleOrDefault(n => n.MaLoai == t.MaLoai);
        //    ViewBag.LoaiThietBi = loai.TenLoai;
        //    return PartialView(t);
        //}

        public IActionResult DanhSachSanPham()
        {
            return View(db.ThietBiYtes.ToList());
        }
        [Authentication]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiThietBis.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaHang = new SelectList(db.HangThietBis.ToList().OrderBy(n => n.TenHang), "MaHang", "TenHang");
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "True" },
                new SelectListItem { Value = "0", Text = "False" }
            };
            ViewBag.An = items;
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
        public IActionResult ThemSanPham([FromBody]ThietBiYte thietbi)
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
            ViewBag.MaHang = new SelectList(db.HangThietBis.ToList().OrderBy(n => n.TenHang), "MaHang", "TenHang");
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "True" },
                new SelectListItem { Value = "0", Text = "False" }
            };
            ViewBag.An = items;
            return View(thietbi);
        }
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SuaSanPham(ThietBiYte thietbi)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(thietbi).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("TrangChu");
        //}

        public int splitId(string id)
        {
            //KH_35
            string res = id.Substring(3, id.Length - 3);
            return int.Parse(res);
        }


        public IActionResult DangKy()
        {
            var lastCustomer = db.KhachHangs.ToList();
            int lastId = splitId(lastCustomer.OrderByDescending(x => splitId(x.MaKh)).FirstOrDefault().MaKh.ToString());
            ViewBag.lastId = lastId;
            return View(lastId);
        }
        //public int splitId(string id)
        //{
        //    string digits = new string(id.Where(char.IsDigit).ToArray());
        //    return int.Parse(digits);
        //}
        //public IActionResult DangKy()
        //{
        //    var lastCustomer = db.KhachHangs.ToList();
        //    int lastId = splitId(lastCustomer.OrderByDescending(x => splitId(x.MaKh)).FirstOrDefault().MaKh.ToString());
        //    ViewBag.lastId = lastId;
        //    return View(lastId);
        //}
    }
}
