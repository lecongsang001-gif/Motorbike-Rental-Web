using System;
using System.Collections.Generic;

namespace Nhom7.Models;

public partial class Xe
{
    public string MaXe { get; set; } = null!;

    public string TenXe { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public string LoaiXeMay { get; set; } = null!;

    public short PhanKhoi { get; set; }

    public short? NamSanXuat { get; set; }

    public string? MauSac { get; set; }

    public string MaLoaiXe { get; set; } = null!;

    public virtual ICollection<ChiTietDonThue> ChiTietDonThues { get; set; } = new List<ChiTietDonThue>();
}
