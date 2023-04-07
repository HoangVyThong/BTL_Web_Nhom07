using System;
using System.Collections.Generic;

namespace BTL_Web_Nhom7.Models;

public partial class ChuQuanLy
{
    public string Ten { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public virtual TaiKhoan IdNavigation { get; set; } = null!;
}
