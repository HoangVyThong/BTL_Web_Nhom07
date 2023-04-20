using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class HangThietBi
{
    public string MaHang { get; set; } = null!;

    public string? TenHang { get; set; }

    public virtual ICollection<ThietBiYte> ThietBiYtes { get; } = new List<ThietBiYte>();
}
