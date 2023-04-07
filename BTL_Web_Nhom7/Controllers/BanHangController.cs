using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BTL_Web_Nhom7.Controllers
{
    public class BanHangController : Controller
    {
        // GET: Index
        BtlWebContext db = new BtlWebContext();
        public ActionResult TrangChu()
        {
            return View(db.DanhMucs.ToList());
        }
        public ActionResult DanhMucSP(String MaDanhMuc)
        {
            var t = db.DanhMucs.SingleOrDefault(n => n.MaDanhMuc == MaDanhMuc);
            return View(t);
        }
        public ActionResult LoaiSanPham(String MaLoai = "L1")
        {
            var t = db.ThietBiYtes.SingleOrDefault(n => n.MaLoai == MaLoai);
            return View(t);
        }
        public ViewResult ChiTietSanPham(string MaSP = "TB1")
        {
            var thietBi = db.ThietBiYtes.SingleOrDefault(n => n.MaThietBi == MaSP);
            if (thietBi.TongSoDanhGia == 0)
            {
                ViewBag.KhongDanhGia = "Thiết bị chưa có đánh giá";
            }
            else
            {
                double Tsao = (double)thietBi.TongSoSao;
                double TDG = (double)thietBi.TongSoDanhGia;

                //ViewBag.SoDanhGia = (Tsao/TDG).ToString() + " sao ("+ thietBi.TongSoDanhGia + " lượt đánh giá)" ;
                string res = Math.Round(Tsao / TDG, 2).ToString();
                ViewBag.SoDanhGia = res + " sao (" + thietBi.TongSoDanhGia + " lượt đánh giá)";

            }

            return View(thietBi);
        }
        public ActionResult DanhGiaSanPham(string MaThietBi, string DanhGia)
        {
            MaThietBi = MaThietBi.Split(')')[0];
            var thietBi = db.ThietBiYtes.SingleOrDefault(n => n.MaThietBi == MaThietBi);
            thietBi.TongSoSao += int.Parse(DanhGia);
            thietBi.TongSoDanhGia++;
            db.SaveChanges();
            return RedirectToAction("ChiTietSanPham", new { MaSP = MaThietBi });
        }
        public ActionResult Sanphamtheoloai()
        {
            return View();
        }
        public PartialViewResult Danhmuc()
        {
            return PartialView(db.DanhMucs.ToList());

        }
        public PartialViewResult LoaiDanhmuc(String MaDanhMuc = "DM1", int sosp1loai = 0)
        {
            List<LoaiThietBi> listLoai = db.LoaiThietBis.Where(n => n.MaDanhMuc == MaDanhMuc).OrderBy(n => n.TenLoai).ToList();
            KeyValuePair<List<LoaiThietBi>, int> keyValuePair = new KeyValuePair<List<LoaiThietBi>, int>(listLoai, sosp1loai);
            return PartialView(keyValuePair);
        }
        public PartialViewResult Loai(String MaDanhmuc)
        {

            var listLoai = db.LoaiThietBis.Where(n => n.MaDanhMuc == MaDanhmuc).OrderBy(n => n.TenLoai).ToList();

            return PartialView(listLoai);
        }
        public PartialViewResult LoaiSP(String MaLoaiSP = "L1")
        {
            var loai = db.ThietBiYtes.SingleOrDefault(n => n.MaLoai == MaLoaiSP);
            return PartialView(loai);

        }
        public PartialViewResult Sanphamtungloai(String MaLoai, int Sosp = 0)
        {
            var listSP = db.ThietBiYtes.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.TenThietBi).ToList();
            if (Sosp != 0)
            {
                listSP = (from s in db.ThietBiYtes
                          where s.MaLoai == MaLoai
                          select s).Take(Sosp).ToList();
            }
            return PartialView(listSP);
        }
        public ActionResult TimKiem(FormCollection f)
        {
            string t = f["timkiem"];
            var thietBiYTes = db.ThietBiYtes.Where(n => n.TenThietBi.Contains(t)).ToList();
            return View(thietBiYTes);
        }

        [HttpPost]
        public ActionResult SearchResults(FormCollection f, int? page)
        {
            string searchkey = f["timkiem"].ToString();
            var lstSearchResults = db.ThietBiYtes.Where(n => n.TenThietBi.Contains(searchkey)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 20;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(new List<ThietBiYte>().ToPagedList(pagenumber, pagesize));
                //return View(db.ThietBiYTes.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.keyword = searchkey;
            ViewBag.ThongBao = "Đã tìm thấy " + lstSearchResults.Count + " sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult SearchResults(int? page, string searchkey)
        {
            ViewBag.keyword = searchkey;
            var lstSearchResults = db.ThietBiYtes.Where(n => n.TenThietBi.Contains(searchkey)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 20;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.ThietBiYtes.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstSearchResults.Count + "  sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.TenThietBi).ToPagedList(pagenumber, pagesize));
        }

    }
}
