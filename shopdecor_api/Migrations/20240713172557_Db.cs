using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaGiamGia = table.Column<string>(type: "Varchar(20)", nullable: false),
                    MoTa = table.Column<string>(type: "Nvarchar(max)", nullable: true),
                    LoaiGiam = table.Column<bool>(type: "bit", nullable: true),
                    MenhGia = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HSD = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaGiamGia);
                });

            migrationBuilder.CreateTable(
                name: "KichThuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKichThuoc = table.Column<string>(type: "Varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichThuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "Nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMauSac = table.Column<string>(type: "Nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTK = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "Nvarchar(200)", nullable: true),
                    MoTa = table.Column<string>(type: "Nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdKhuyenMai = table.Column<string>(type: "Varchar(20)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuyenMaiMaGiamGia = table.Column<string>(type: "Varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_KhuyenMai_KhuyenMaiMaGiamGia",
                        column: x => x.KhuyenMaiMaGiamGia,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaGiamGia");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    IdKhuyenMai = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDoHuy = table.Column<string>(type: "Nvarchar(max)", nullable: true),
                    TTDonHang = table.Column<byte>(type: "tinyint", nullable: false),
                    TTThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true),
                    KhuyenMaiMaGiamGia = table.Column<string>(type: "Varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_KhuyenMai_KhuyenMaiMaGiamGia",
                        column: x => x.KhuyenMaiMaGiamGia,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaGiamGia");
                    table.ForeignKey(
                        name: "FK_DonHang_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinh = table.Column<string>(type: "Varchar(max)", nullable: true),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hinh_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPham_ChiTiet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKichThuoc = table.Column<int>(type: "int", nullable: false),
                    IdMauSac = table.Column<int>(type: "int", nullable: false),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    KichThuocId = table.Column<int>(type: "int", nullable: true),
                    MauSacId = table.Column<int>(type: "int", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_ChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_ChiTiet_KichThuoc_KichThuocId",
                        column: x => x.KichThuocId,
                        principalTable: "KichThuoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_ChiTiet_MauSac_MauSacId",
                        column: x => x.MauSacId,
                        principalTable: "MauSac",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_ChiTiet_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPham_Loai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdLoai = table.Column<int>(type: "int", nullable: false),
                    LoaiSPId = table.Column<int>(type: "int", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_Loai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_Loai_LoaiSP_LoaiSPId",
                        column: x => x.LoaiSPId,
                        principalTable: "LoaiSP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_Loai_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonHang_ChiTiet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdDonHang = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaSP = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: true),
                    DonHangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang_ChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_ChiTiet_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonHang_ChiTiet_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayXuatHD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDonHang = table.Column<int>(type: "int", nullable: false),
                    DonHangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_KhuyenMaiMaGiamGia",
                table: "DonHang",
                column: "KhuyenMaiMaGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_TaiKhoanId",
                table: "DonHang",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ChiTiet_DonHangId",
                table: "DonHang_ChiTiet",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ChiTiet_SanPhamId",
                table: "DonHang_ChiTiet",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_Hinh_SanPhamId",
                table: "Hinh",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_DonHangId",
                table: "HoaDon",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_KhuyenMaiMaGiamGia",
                table: "SanPham",
                column: "KhuyenMaiMaGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ChiTiet_KichThuocId",
                table: "SanPham_ChiTiet",
                column: "KichThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ChiTiet_MauSacId",
                table: "SanPham_ChiTiet",
                column: "MauSacId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ChiTiet_SanPhamId",
                table: "SanPham_ChiTiet",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_Loai_LoaiSPId",
                table: "SanPham_Loai",
                column: "LoaiSPId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_Loai_SanPhamId",
                table: "SanPham_Loai",
                column: "SanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang_ChiTiet");

            migrationBuilder.DropTable(
                name: "Hinh");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham_ChiTiet");

            migrationBuilder.DropTable(
                name: "SanPham_Loai");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "KichThuoc");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "LoaiSP");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "KhuyenMai");
        }
    }
}
