using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class updateeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "DonHang_ChiTiet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MauSac",
                table: "DonHang_ChiTiet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "DonHang_ChiTiet");

            migrationBuilder.DropColumn(
                name: "MauSac",
                table: "DonHang_ChiTiet");
        }
    }
}
