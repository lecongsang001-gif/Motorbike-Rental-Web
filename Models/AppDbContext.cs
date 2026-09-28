using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nhom7.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonThue> ChiTietDonThues { get; set; }

    public virtual DbSet<DonThueXe> DonThueXes { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CHOCOOPIE\\SQLEXPRESS;Database=Motorbike;User Id=nhom7;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonThue>(entity =>
        {
            entity.HasKey(e => new { e.MaDon, e.MaXe }).HasName("PK__ChiTietD__FFFBA7647FF64E4B");

            entity.ToTable("ChiTietDonThue");

            entity.Property(e => e.MaDon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaXe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DonGiaThue).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaDonNavigation).WithMany(p => p.ChiTietDonThues)
                .HasForeignKey(d => d.MaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTiet_DonThue");

            entity.HasOne(d => d.MaXeNavigation).WithMany(p => p.ChiTietDonThues)
                .HasForeignKey(d => d.MaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTiet_Xe");
        });

        modelBuilder.Entity<DonThueXe>(entity =>
        {
            entity.HasKey(e => e.MaDon).HasName("PK__DonThueX__3D89F568709BD3DF");

            entity.ToTable("DonThueXe");

            entity.Property(e => e.MaDon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CocXe)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgayDat).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Chờ xác nhận");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DonThueXes)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonThue_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DonThueXes)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_DonThue_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5EF01F107");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Cccd, "UQ__KhachHan__A955A0AAF5C74B3F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__KhachHan__A9D10534BD3DF665").IsUnique();

            entity.HasIndex(e => e.Sdt, "UQ__KhachHan__CA1930A50AC4FD3A").IsUnique();

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CapDoVip)
                .HasMaxLength(30)
                .HasDefaultValue("Thường")
                .HasColumnName("CapDoVIP");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gplx)
                .HasDefaultValue(false)
                .HasColumnName("GPLX");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA4770521206");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Email, "UQ__NhanVien__A9D105348A2576C7").IsUnique();

            entity.HasIndex(e => e.Sdt, "UQ__NhanVien__CA1930A5B939D9E8").IsUnique();

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Đang làm");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C6529FD45D25C");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0726560FE").IsUnique();

            entity.HasIndex(e => e.MaNhanVien, "UQ__TaiKhoan__77B2CA46B9B49418").IsUnique();

            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(100)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Hoạt động");
            entity.Property(e => e.VaiTro).HasMaxLength(30);

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.TaiKhoan)
                .HasForeignKey<TaiKhoan>(d => d.MaNhanVien)
                .HasConstraintName("FK_TaiKhoan_NhanVien");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__D4B258447DDBB98D");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaThanhToan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaDon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgayThanhToan).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PhuongThuc).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienCoc)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Chờ thanh toán");

            entity.HasOne(d => d.MaDonNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_DonThue");
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.MaXe).HasName("PK__Xe__272520CD79878C58");

            entity.ToTable("Xe");

            entity.Property(e => e.MaXe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LoaiXeMay).HasMaxLength(50);
            entity.Property(e => e.MaLoaiXe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MauSac).HasMaxLength(50);
            entity.Property(e => e.TenHang).HasMaxLength(50);
            entity.Property(e => e.TenXe).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
