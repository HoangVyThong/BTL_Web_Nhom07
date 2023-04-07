using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class TaiKhoan
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<ChuQuanLy> ChuQuanLies { get; } = new List<ChuQuanLy>();
}
