using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAPIController : ControllerBase
    {
        BtlApiContext db = new BtlApiContext();
        [Route("{searchkey}")]
        public IActionResult Search(string searchkey)
        {
            var lstSearchResults = db.ThietBiYtes
                .Where(n => n.TenThietBi.Contains(searchkey))
                .OrderBy(n => n.TenThietBi)
                .ToList();

            if (lstSearchResults.Count == 0)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm bạn tìm kiếm" });
            }

            return Ok(
            
                 lstSearchResults
            );
        }

    }
}
