using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Models.ModelProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [Route("{maLoai}")]
        public IEnumerable<ProductDTO> GetProductByMaLoai(string maLoai)
        {
            var products = (from p in db.ThietBiYtes
                            join q in db.LoaiThietBis on p.MaLoai equals q.MaLoai
                            where p.MaLoai == maLoai
                            select new ProductDTO
                            {
                                MaThietBi = p.MaThietBi,
                                MaLoai = q.MaLoai,
                                TenThietBi = p.TenThietBi,
                                TenLoai = q.TenLoai,
                                GioiThieu = p.GioiThieu,
                                GiaBan = p.GiaBan,
                                GiamGia = p.GiamGia,
                                Anh = p.Anh
                            }).ToList();
            return products;
        }
    }
}
