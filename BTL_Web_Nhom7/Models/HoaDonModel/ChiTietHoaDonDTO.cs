namespace BTL_Web_Nhom7.Models.HoaDonModel
{
    public class ChiTietHoaDonDTO
    {
        public string SoHdb { get; set; } = null!;
        public string? TenThietBi { get; set; }
        public int? SoLuong { get; set; }
        public string? Anh { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? ThanhTien { get; set; }
    }
}
