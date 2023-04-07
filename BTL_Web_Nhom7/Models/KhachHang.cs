using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();
}
