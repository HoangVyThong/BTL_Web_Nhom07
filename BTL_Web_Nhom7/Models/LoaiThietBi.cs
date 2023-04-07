using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class LoaiThietBi
{
    public string MaLoai { get; set; } = null!;

    public string? MaDanhMuc { get; set; }

    public string? TenLoai { get; set; }

    public virtual DanhMuc? MaDanhMucNavigation { get; set; }

    public virtual ICollection<ThietBiYte> ThietBiYtes { get; } = new List<ThietBiYte>();
}
