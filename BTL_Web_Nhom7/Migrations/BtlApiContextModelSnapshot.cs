﻿// <auto-generated />
using System;
using BTL_Web_Nhom7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTL_Web_Nhom7.Migrations
{
    [DbContext(typeof(BtlApiContext))]
    partial class BtlApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTL_Web_Nhom7.Models.ChiTietHdb", b =>
                {
                    b.Property<string>("MaThietBi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoHdb")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SoHDB");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("money");

                    b.HasKey("MaThietBi", "SoHdb");

                    b.HasIndex("SoHdb");

                    b.ToTable("ChiTietHDB", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.DanhMuc", b =>
                {
                    b.Property<string>("MaDanhMuc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenDanhMuc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDanhMuc");

                    b.ToTable("DanhMuc", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.HangThietBi", b =>
                {
                    b.Property<string>("MaHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaHang");

                    b.ToTable("HangThietBi", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.HoaDonBan", b =>
                {
                    b.Property<string>("SoHdb")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SoHDB");

                    b.Property<string>("MaKh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MaKH");

                    b.Property<DateTime?>("NgayLap")
                        .HasColumnType("datetime");

                    b.HasKey("SoHdb");

                    b.HasIndex("MaKh");

                    b.ToTable("HoaDonBan", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MaKH");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TenKh")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("TenKH");

                    b.Property<string>("TenTaiKhoan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKh");

                    b.HasIndex("TenTaiKhoan");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.LoaiTaiKhoan", b =>
                {
                    b.Property<int>("MaLoaiTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiTaiKhoan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoaiTaiKhoan");

                    b.ToTable("LoaiTaiKhoan", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.LoaiThietBi", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaDanhMuc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("MaLoai");

                    b.HasIndex("MaDanhMuc");

                    b.ToTable("LoaiThietBi", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.TaiKhoan", b =>
                {
                    b.Property<string>("TenTaiKhoan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaLoaiTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TenTaiKhoan");

                    b.HasIndex("MaLoaiTaiKhoan");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.ThietBiYte", b =>
                {
                    b.Property<string>("MaThietBi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("An")
                        .HasColumnType("bit");

                    b.Property<string>("Anh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("money");

                    b.Property<double?>("GiamGia")
                        .HasColumnType("float");

                    b.Property<string>("GioiThieu")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MaHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaLoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenThietBi")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("TongSoDanhGia")
                        .HasColumnType("int");

                    b.Property<int?>("TongSoSao")
                        .HasColumnType("int");

                    b.HasKey("MaThietBi")
                        .HasName("PK_ThietBi");

                    b.HasIndex("MaHang");

                    b.HasIndex("MaLoai");

                    b.ToTable("ThietBiYTe", (string)null);
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.ChiTietHdb", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.ThietBiYte", "MaThietBiNavigation")
                        .WithMany("ChiTietHdbs")
                        .HasForeignKey("MaThietBi")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietHDB_ThietBiYTe");

                    b.HasOne("BTL_Web_Nhom7.Models.HoaDonBan", "SoHdbNavigation")
                        .WithMany("ChiTietHdbs")
                        .HasForeignKey("SoHdb")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietHDB_HoaDonBan");

                    b.Navigation("MaThietBiNavigation");

                    b.Navigation("SoHdbNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.HoaDonBan", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.KhachHang", "MaKhNavigation")
                        .WithMany("HoaDonBans")
                        .HasForeignKey("MaKh")
                        .HasConstraintName("FK_HoaDonBan_KhachHang");

                    b.Navigation("MaKhNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.KhachHang", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.TaiKhoan", "TenTaiKhoanNavigation")
                        .WithMany("KhachHangs")
                        .HasForeignKey("TenTaiKhoan")
                        .HasConstraintName("FK_KhachHang_TaiKhoan");

                    b.Navigation("TenTaiKhoanNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.LoaiThietBi", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.DanhMuc", "MaDanhMucNavigation")
                        .WithMany("LoaiThietBis")
                        .HasForeignKey("MaDanhMuc")
                        .HasConstraintName("FK_LoaiThietBi_DanhMuc");

                    b.Navigation("MaDanhMucNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.TaiKhoan", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.LoaiTaiKhoan", "MaLoaiTaiKhoanNavigation")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("MaLoaiTaiKhoan")
                        .HasConstraintName("FK_TaiKhoan_LoaiTaiKhoan");

                    b.Navigation("MaLoaiTaiKhoanNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.ThietBiYte", b =>
                {
                    b.HasOne("BTL_Web_Nhom7.Models.HangThietBi", "MaHangNavigation")
                        .WithMany("ThietBiYtes")
                        .HasForeignKey("MaHang")
                        .HasConstraintName("FK_ThietBiYTe_HangThietBi");

                    b.HasOne("BTL_Web_Nhom7.Models.LoaiThietBi", "MaLoaiNavigation")
                        .WithMany("ThietBiYtes")
                        .HasForeignKey("MaLoai")
                        .HasConstraintName("FK_ThietBiYTe_LoaiThietBi");

                    b.Navigation("MaHangNavigation");

                    b.Navigation("MaLoaiNavigation");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.DanhMuc", b =>
                {
                    b.Navigation("LoaiThietBis");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.HangThietBi", b =>
                {
                    b.Navigation("ThietBiYtes");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.HoaDonBan", b =>
                {
                    b.Navigation("ChiTietHdbs");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDonBans");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.LoaiTaiKhoan", b =>
                {
                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.LoaiThietBi", b =>
                {
                    b.Navigation("ThietBiYtes");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.TaiKhoan", b =>
                {
                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("BTL_Web_Nhom7.Models.ThietBiYte", b =>
                {
                    b.Navigation("ChiTietHdbs");
                });
#pragma warning restore 612, 618
        }
    }
}
