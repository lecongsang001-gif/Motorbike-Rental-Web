using System;
using System.Collections.Generic;

namespace Nhom7.Models;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string? MaNhanVien { get; set; }

    public string? TaiKhoan1 { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public string? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? DangNhapLanCuoi { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
