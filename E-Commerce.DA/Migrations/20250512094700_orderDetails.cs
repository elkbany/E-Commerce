using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class orderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 5 },
                    { 3, 2, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
