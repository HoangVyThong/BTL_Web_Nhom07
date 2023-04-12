namespace BTL_Web_Nhom7.Models.HoaDonModel
{
    public class HoaDonDTO
    {
        public string SoHdb { get; set; } = null!;
        public string? TenKh { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgayLap { get; set; }
        public decimal? ThanhTien { get; set; }

        public HoaDonDTO() { }
        public HoaDonDTO(string soHdb, string? tenKh, string? dienThoai, string? diaChi, DateTime? ngayLap, decimal? thanhTien)
        {
            SoHdb = soHdb;
            TenKh = tenKh;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            NgayLap = ngayLap;
            ThanhTien = thanhTien;
        }
    }
}
