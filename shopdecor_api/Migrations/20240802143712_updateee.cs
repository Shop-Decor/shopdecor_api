using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class updateee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "DonHang");
        }
    }
}
