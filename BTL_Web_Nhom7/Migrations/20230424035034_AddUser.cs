using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Web_Nhom7.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    MaDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "HangThietBi",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangThietBi", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTaiKhoan",
                columns: table => new
                {
                    MaLoaiTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TenLoaiTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiKhoan", x => x.MaLoaiTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBi",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenLoai = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBi", x => x.MaLoai);
                    table.ForeignKey(
                        name: "FK_LoaiThietBi_DanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "MaDanhMuc");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaLoaiTaiKhoan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TenTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_LoaiTaiKhoan",
                        column: x => x.MaLoaiTaiKhoan,
                        principalTable: "LoaiTaiKhoan",
                        principalColumn: "MaLoaiTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "ThietBiYTe",
                columns: table => new
                {
                    MaThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenThietBi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GioiThieu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GiaBan = table.Column<decimal>(type: "money", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    An = table.Column<bool>(type: "bit", nullable: true),
                    GiamGia = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TongSoSao = table.Column<int>(type: "int", nullable: true),
                    TongSoDanhGia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBi", x => x.MaThietBi);
                    table.ForeignKey(
                        name: "FK_ThietBiYTe_HangThietBi",
                        column: x => x.MaHang,
                        principalTable: "HangThietBi",
                        principalColumn: "MaHang");
                    table.ForeignKey(
                        name: "FK_ThietBiYTe_LoaiThietBi",
                        column: x => x.MaLoai,
                        principalTable: "LoaiThietBi",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KhachHang_TaiKhoan",
                        column: x => x.TenTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "TenTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonBan",
                columns: table => new
                {
                    SoHDB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonBan", x => x.SoHDB);
                    table.ForeignKey(
                        name: "FK_HoaDonBan_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHDB",
                columns: table => new
                {
                    MaThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoHDB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHDB", x => new { x.MaThietBi, x.SoHDB });
                    table.ForeignKey(
                        name: "FK_ChiTietHDB_HoaDonBan",
                        column: x => x.SoHDB,
                        principalTable: "HoaDonBan",
                        principalColumn: "SoHDB");
                    table.ForeignKey(
                        name: "FK_ChiTietHDB_ThietBiYTe",
                        column: x => x.MaThietBi,
                        principalTable: "ThietBiYTe",
                        principalColumn: "MaThietBi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHDB_SoHDB",
                table: "ChiTietHDB",
                column: "SoHDB");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBan_MaKH",
                table: "HoaDonBan",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_TenTaiKhoan",
                table: "KhachHang",
                column: "TenTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBi_MaDanhMuc",
                table: "LoaiThietBi",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaLoaiTaiKhoan",
                table: "TaiKhoan",
                column: "MaLoaiTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBiYTe_MaHang",
                table: "ThietBiYTe",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBiYTe_MaLoai",
                table: "ThietBiYTe",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHDB");

            migrationBuilder.DropTable(
                name: "HoaDonBan");

            migrationBuilder.DropTable(
                name: "ThietBiYTe");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "HangThietBi");

            migrationBuilder.DropTable(
                name: "LoaiThietBi");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "LoaiTaiKhoan");
        }
    }
}
