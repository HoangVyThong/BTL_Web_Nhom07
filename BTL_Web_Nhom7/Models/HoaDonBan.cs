using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class HoaDonBan
{
    public string SoHdb { get; set; } = null!;

    public string? MaKh { get; set; }

    public DateTime? NgayLap { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; } = new List<ChiTietHdb>();

    public virtual KhachHang? MaKhNavigation { get; set; }
}
