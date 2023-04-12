using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Models.HoaDonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [Route("{SoHD}")]
        public IEnumerable<ChiTietHoaDonDTO> GetChiTietHoaDon(string SoHD)
        {
            var hoadon = (from p in db.ChiTietHdbs
                     join q in db.ThietBiYtes on p.MaThietBi equals q.MaThietBi
                     where p.SoHdb == SoHD
                     select new ChiTietHoaDonDTO
                     {
                         SoHdb = p.SoHdb,
                         TenThietBi = q.TenThietBi,
                         Anh = q.Anh,
                         SoLuong = q.SoLuong,
                         GiaBan = q.GiaBan,
                         ThanhTien = p.ThanhTien
                     }).ToList();
            return hoadon;
        }
    }
}
