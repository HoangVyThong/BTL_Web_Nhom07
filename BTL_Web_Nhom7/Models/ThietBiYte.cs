using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class ThietBiYte
{
    public string MaThietBi { get; set; } = null!;

    public string? MaLoai { get; set; }

    public string? MaHang { get; set; }

    public string? TenThietBi { get; set; }

    public string? GioiThieu { get; set; }

    public decimal? GiaBan { get; set; }

    public string? Anh { get; set; }

    public string? ChiTiet { get; set; }

    public bool? An { get; set; }

    public double? GiamGia { get; set; }

    public int? SoLuong { get; set; }

    public int? TongSoSao { get; set; }

    public int? TongSoDanhGia { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; } = new List<ChiTietHdb>();

    public virtual HangThietBi? MaHangNavigation { get; set; }

    public virtual LoaiThietBi? MaLoaiNavigation { get; set; }
}
