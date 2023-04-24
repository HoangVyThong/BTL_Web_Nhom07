using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        BtlApiContext db = new BtlApiContext();
        [HttpPost]
        public bool AddProduct([FromBody] ThietBiYte thietBiYte)
        {
            db.ThietBiYtes.Add(thietBiYte);
            db.SaveChanges();
            return true;
        }

        [HttpPut]
        public bool UpdateProduct([FromBody] ThietBiYte thietBiYte)
        {
            db.Entry(thietBiYte).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        [HttpDelete]
        public bool DeleteProduct(string MaTB)
        {
            var product = db.ThietBiYtes.FirstOrDefault(x => x.MaThietBi.Equals(MaTB));
            if (product == null)
            {
                return false;
            }
            else
            {
                db.ThietBiYtes.Remove(product);
                db.SaveChanges();
                return true;
            }
        }

        [Authorize]
        public IEnumerable<ThietBiYte> GetAllProduct()
        {
            return db.ThietBiYtes.ToList();
        }
    }
}
