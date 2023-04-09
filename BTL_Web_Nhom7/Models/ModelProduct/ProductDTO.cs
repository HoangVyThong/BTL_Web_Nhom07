namespace BTL_Web_Nhom7.Models.ModelProduct
{
	public class ProductDTO
	{
		public string MaThietBi { get; set; } = null!;
		public string? MaLoai { get; set; }

		public string? TenThietBi { get; set; }
        public string? TenLoai { get; set; }
        public string? GioiThieu { get; set; }
        public decimal? GiaBan { get; set; }
        public double? GiamGia { get; set; }

        public string? Anh { get; set; }
	}
}
