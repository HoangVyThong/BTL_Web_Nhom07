using BTL_Web_Nhom7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyAPIController : ControllerBase
    {
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
        [HttpPost]
        [Route("DangKy")]
        public bool DangKy(String MaKhachHang, String SoDienThoai,
            String Email, String TaiKhoan, String MatKhau)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                TaiKhoan taikhoan = new TaiKhoan();
                taikhoan.TenTaiKhoan = TaiKhoan;
                taikhoan.Password = GetMd5Hash(md5Hash, MatKhau.ToString());
                taikhoan.MaLoaiTaiKhoan = 1;
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();

                KhachHang khach = new KhachHang();
                khach.MaKh = MaKhachHang;
                khach.TenKh = "h";

                khach.DienThoai = SoDienThoai;
                khach.DiaChi = "h";
                khach.Email = Email;

                khach.TenTaiKhoan = TaiKhoan;
                db.KhachHangs.Add(khach);
                db.SaveChanges();
                return true;
            }
        }
    }
}
