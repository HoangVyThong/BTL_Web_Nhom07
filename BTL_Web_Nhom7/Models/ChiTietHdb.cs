using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class ChiTietHdb
{
    public string MaThietBi { get; set; } = null!;

    public string SoHdb { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual ThietBiYte MaThietBiNavigation { get; set; } = null!;
}
