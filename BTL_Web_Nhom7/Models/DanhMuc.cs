using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class DanhMuc
{
    public string MaDanhMuc { get; set; } = null!;

    public string? TenDanhMuc { get; set; }

    public virtual ICollection<LoaiThietBi> LoaiThietBis { get; } = new List<LoaiThietBi>();
}
