using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class updateaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_TaiKhoan_TaiKhoanId",
                table: "DonHang");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_TaiKhoanId",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TaiKhoanId",
                table: "DonHang");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hinh",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DonHang",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hinh_UserId",
                table: "Hinh",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ApplicationUserId",
                table: "DonHang",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_AspNetUsers_ApplicationUserId",
                table: "DonHang",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hinh_AspNetUsers_UserId",
                table: "Hinh",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_AspNetUsers_ApplicationUserId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_Hinh_AspNetUsers_UserId",
                table: "Hinh");

            migrationBuilder.DropIndex(
                name: "IX_Hinh_UserId",
                table: "Hinh");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_ApplicationUserId",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hinh");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DonHang");

            migrationBuilder.AddColumn<int>(
                name: "TaiKhoanId",
                table: "DonHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTK = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_TaiKhoanId",
                table: "DonHang",
                column: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_TaiKhoan_TaiKhoanId",
                table: "DonHang",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "Id");
        }
    }
}
