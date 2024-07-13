using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class Db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLoai",
                table: "SanPham_Loai");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "SanPham_Loai");

            migrationBuilder.DropColumn(
                name: "IdKichThuoc",
                table: "SanPham_ChiTiet");

            migrationBuilder.DropColumn(
                name: "IdMauSac",
                table: "SanPham_ChiTiet");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "SanPham_ChiTiet");

            migrationBuilder.DropColumn(
                name: "IdKhuyenMai",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IdDonHang",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "IdDonHang",
                table: "DonHang_ChiTiet");

            migrationBuilder.DropColumn(
                name: "IdSanPham",
                table: "DonHang_ChiTiet");

            migrationBuilder.DropColumn(
                name: "IdKhuyenMai",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "IdTaiKhoan",
                table: "DonHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLoai",
                table: "SanPham_Loai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "SanPham_Loai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdKichThuoc",
                table: "SanPham_ChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMauSac",
                table: "SanPham_ChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "SanPham_ChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdKhuyenMai",
                table: "SanPham",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdDonHang",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDonHang",
                table: "DonHang_ChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSanPham",
                table: "DonHang_ChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdKhuyenMai",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTaiKhoan",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
