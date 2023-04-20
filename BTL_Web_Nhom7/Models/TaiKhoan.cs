using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class TaiKhoan
{
    public string TenTaiKhoan { get; set; } = null!;

    public string? Password { get; set; }

    public int? MaLoaiTaiKhoan { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();

    public virtual LoaiTaiKhoan? MaLoaiTaiKhoanNavigation { get; set; }
}
