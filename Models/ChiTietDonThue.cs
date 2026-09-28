using System;
using System.Collections.Generic;

namespace Nhom7.Models;

public partial class ChiTietDonThue
{
    public string MaDon { get; set; } = null!;

    public string MaXe { get; set; } = null!;

    public decimal DonGiaThue { get; set; }

    public virtual DonThueXe MaDonNavigation { get; set; } = null!;

    public virtual Xe MaXeNavigation { get; set; } = null!;
}
