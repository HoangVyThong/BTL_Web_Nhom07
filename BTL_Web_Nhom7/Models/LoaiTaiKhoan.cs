using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class LoaiTaiKhoan
{
    public int MaLoaiTaiKhoan { get; set; }

    public string? TenLoaiTaiKhoan { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; } = new List<TaiKhoan>();
}
