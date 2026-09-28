using System;
using System.Collections.Generic;

namespace Nhom7.Models;

public partial class DonThueXe
{
    public string MaDon { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string? MaNhanVien { get; set; }

    public DateTime? NgayDat { get; set; }

    public DateTime NgayNhan { get; set; }

    public DateTime NgayTra { get; set; }

    public decimal? CocXe { get; set; }

    public string? TrangThai { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietDonThue> ChiTietDonThues { get; set; } = new List<ChiTietDonThue>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
