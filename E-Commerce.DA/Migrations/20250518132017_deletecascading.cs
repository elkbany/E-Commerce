using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class deletecascading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
