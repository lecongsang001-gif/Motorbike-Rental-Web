using System;
using System.Collections.Generic;

namespace Nhom7.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? ChucVu { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<DonThueXe> DonThueXes { get; set; } = new List<DonThueXe>();

    public virtual TaiKhoan? TaiKhoan { get; set; }
}
