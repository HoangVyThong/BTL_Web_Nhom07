namespace BTL_Web_Nhom7.Models
{
    public class GioHang
    {
        BtlWebContext db = new BtlWebContext();
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string Anh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public int Max { get; set; }
        public int ThanhTien1 { get; set; }
        public int ThanhTien3 { get; set; }
        public double ThanhTien
        {
            get { return DonGia * SoLuong; }
            set { }
        }
        public GioHang() {  }
        public GioHang(string MaThietBi)
        {
            this.MaThietBi = MaThietBi;
            var sanpham = db.ThietBiYtes.Single(n => n.MaThietBi == MaThietBi);
            TenThietBi = sanpham.TenThietBi;
            this.Anh = sanpham.Anh;
            DonGia = (double)sanpham.GiaBan;
            if ((int)sanpham.SoLuong == 0)
            {
                SoLuong = 0;
            }
            else
            {
                SoLuong = 1;
            }
            Max = (int)sanpham.SoLuong;
        }
    }
}
