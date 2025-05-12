using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class orderseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "DateProcessed", "OrderDate", "Status", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 5, 11, 3, 0, 0, 0, DateTimeKind.Local), 0, 150.00m, 1 },
                    { 2, new DateTime(2025, 5, 12, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 12, 3, 0, 0, 0, DateTimeKind.Local), 1, 275.50m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);
        }
    }
}
