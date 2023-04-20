using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTL_Web_Nhom7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BtlApiContext db = new BtlApiContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var danhMucs = db.DanhMucs.ToList();
            var sanPham1 = db.ThietBiYtes.Where(x => x.MaLoai == "L1").Take(4).ToList();
			var sanPham2 = db.ThietBiYtes.Where(x => x.MaLoai == "L10").Take(4).ToList();
			var sanPham3 = db.ThietBiYtes.Where(x => x.MaLoai == "DM3");
			var sanPham4 = db.ThietBiYtes.Where(x => x.MaLoai == "DM4");
			var sanPham5 = db.ThietBiYtes.Where(x => x.MaLoai == "DM5");
			var sanPham6 = db.ThietBiYtes.Where(x => x.MaLoai == "DM6");
			var sanPham7 = db.ThietBiYtes.Where(x => x.MaLoai == "DM7");
            ViewBag.sanPham1 = sanPham1;
			ViewBag.sanPham2 = sanPham2;
			ViewBag.sanPham3 = sanPham3;
			ViewBag.sanPham4 = sanPham4;
			ViewBag.sanPham5 = sanPham5;
			ViewBag.sanPham6 = sanPham6;
			ViewBag.sanPham7 = sanPham7;
			return View(danhMucs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}