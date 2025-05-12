using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class editmoreseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "DateProcessed", "OrderDate", "Status", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 5, 15, 7, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 15, 3, 0, 0, 0, DateTimeKind.Local), 1, 1349.98m, 1 },
                    { 6, null, new DateTime(2025, 5, 16, 3, 0, 0, 0, DateTimeKind.Local), 0, 99.97m, 2 },
                    { 7, new DateTime(2025, 5, 17, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 17, 3, 0, 0, 0, DateTimeKind.Local), 3, 164.96m, 3 },
                    { 8, new DateTime(2025, 5, 18, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 18, 3, 0, 0, 0, DateTimeKind.Local), 1, 29.98m, 4 },
                    { 9, null, new DateTime(2025, 5, 19, 3, 0, 0, 0, DateTimeKind.Local), 0, 279.97m, 1 },
                    { 10, new DateTime(2025, 5, 20, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 20, 3, 0, 0, 0, DateTimeKind.Local), 1, 199.97m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 9, 1, "Noise-cancelling over-ear headphones", "Wireless Headphones", 199.99m, 3000 },
                    { 10, 1, "Fitness tracking smart watch", "Smart Watch", 249.99m, 2500 },
                    { 11, 2, "Water-resistant winter jacket", "Jacket", 79.99m, 4000 },
                    { 12, 2, "Comfortable running sneakers", "Sneakers", 69.99m, 5000 },
                    { 13, 3, "Gripping mystery thriller", "Mystery Novel", 12.99m, 12000 },
                    { 14, 3, "Comprehensive world history text", "History Book", 29.99m, 7000 },
                    { 15, 4, "Multi-function air fryer", "Air Fryer", 119.99m, 2000 },
                    { 16, 4, "Compact toaster oven with multiple settings", "Toaster Oven", 79.99m, 3500 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Username",
                value: "admin2");

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "DateAdded", "ProductID", "Quantity", "UserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 5, 19, 13, 0, 0, 0, DateTimeKind.Local), 13, 2, 1 },
                    { 6, new DateTime(2025, 5, 20, 15, 0, 0, 0, DateTimeKind.Local), 15, 1, 2 },
                    { 7, new DateTime(2025, 5, 21, 18, 0, 0, 0, DateTimeKind.Local), 14, 1, 3 },
                    { 8, new DateTime(2025, 5, 22, 12, 0, 0, 0, DateTimeKind.Local), 16, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 9, 5, 3, 1 },
                    { 10, 5, 2, 2 },
                    { 11, 6, 4, 1 },
                    { 12, 6, 8, 1 },
                    { 13, 7, 7, 1 },
                    { 14, 7, 6, 3 },
                    { 15, 8, 5, 2 },
                    { 16, 8, 2, 1 },
                    { 17, 9, 9, 1 },
                    { 18, 9, 11, 1 },
                    { 19, 10, 10, 1 },
                    { 20, 10, 12, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Username",
                value: "SuperAdmin");
        }
    }
}
