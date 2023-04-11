using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_Web_Nhom7.Models;

public partial class BtlWebContext : DbContext
{
    public BtlWebContext()
    {
    }

    public BtlWebContext(DbContextOptions<BtlWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChuQuanLy> ChuQuanLies { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<HangThietBi> HangThietBis { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiThietBi> LoaiThietBis { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThietBiYte> ThietBiYtes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //DESKTOP-N6MGE3E\SQLEXPRESS
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=BTL_Web;Integrated Security=True;Connect Timeout=       30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaThietBi, e.SoHdb }).HasName("PK_HDB_ThietBiYTe");

            entity.ToTable("ChiTietHDB");

            entity.Property(e => e.MaThietBi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoHdb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoHDB");
            entity.Property(e => e.ThanhTien).HasColumnType("money");

            entity.HasOne(d => d.MaThietBiNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaThietBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDB_ThietBiYTe");
        });

        modelBuilder.Entity<ChuQuanLy>(entity =>
        {
            entity.HasKey(e => e.Ten);

            entity.ToTable("ChuQuanLy");

            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.ChuQuanLies)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChuQuanLy_ID");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDanhMuc);

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDanhMuc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenDanhMuc).HasMaxLength(80);
        });

        modelBuilder.Entity<HangThietBi>(entity =>
        {
            entity.HasKey(e => e.MaHang);

            entity.ToTable("HangThietBi");

            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(10);
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.SoHdb);

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.SoHdb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoHDB");
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.NgayLap).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_HoaDonBan_MaKH");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<LoaiThietBi>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiThietBi");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaDanhMuc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(80);

            entity.HasOne(d => d.MaDanhMucNavigation).WithMany(p => p.LoaiThietBis)
                .HasForeignKey(d => d.MaDanhMuc)
                .HasConstraintName("FK_LoaiThietBi_MaDanhMuc");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<ThietBiYte>(entity =>
        {
            entity.HasKey(e => e.MaThietBi);

            entity.ToTable("ThietBiYTe");

            entity.Property(e => e.MaThietBi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.GioiThieu).HasMaxLength(280);
            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenThietBi).HasMaxLength(80);

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.ThietBiYtes)
                .HasForeignKey(d => d.MaHang)
                .HasConstraintName("FK_ThietBiYTe_MaHang");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.ThietBiYtes)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_ThietBiYTe_MaLoai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
