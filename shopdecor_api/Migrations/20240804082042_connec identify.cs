using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopdecor_api.Migrations
{
    /// <inheritdoc />
    public partial class connecidentify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DonHang",
                type: "nvarchar(450)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_AspNetUsers_ApplicationUserId",
                table: "DonHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_ApplicationUserId",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DonHang");
        }
    }
}
