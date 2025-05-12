using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class editseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Fiction and non-fiction books", "Books" },
                    { 4, "Appliances and home goods", "Home & Kitchen" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 3, 1, "High-performance laptop", "Laptop", 1299.99m, 2000 },
                    { 4, 2, "Denim blue jeans", "Jeans", 49.99m, 6000 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "user");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsActive", "IsSignedInNow", "LastLoginDate", "LastName", "PasswordHash", "Status", "Username" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 5, 11, 3, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 11, 3, 0, 0, 0, DateTimeKind.Local), "superadmin@admin.com", "Super", true, false, null, "Admin", "AQAAAAIAAYagAAAAECtJWIRqgoBEDzcFOu4Kz0LCY/MSge+0SZns5va/p5u6Gg4O87dz1beHha+iyFbsHA==", 0, "SuperAdmin" },
                    { 4, new DateTime(2025, 5, 11, 3, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 11, 3, 0, 0, 0, DateTimeKind.Local), "jane@client.com", "Jane", true, false, null, "Doe", "AQAAAAIAAYagAAAAEBHDiyLRTxpFa9qgoSrzKlEMb2TQjBd1itcvuGrwgvtx80k7zeKga6KPH7+QO+522w==", 1, "user2" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "DateAdded", "ProductID", "Quantity", "UserID" },
                values: new object[] { 1, new DateTime(2025, 5, 11, 13, 0, 0, 0, DateTimeKind.Local), 3, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 3, 2, 3, 1 },
                    { 4, 2, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "DateProcessed", "OrderDate", "Status", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 5, 13, 6, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 13, 3, 0, 0, 0, DateTimeKind.Local), 3, 739.97m, 3 },
                    { 4, null, new DateTime(2025, 5, 14, 3, 0, 0, 0, DateTimeKind.Local), 0, 104.97m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 5, 3, "Best-selling science fiction book", "Sci-Fi Novel", 14.99m, 10000 },
                    { 6, 3, "Collection of gourmet recipes", "Cookbook", 24.99m, 8000 },
                    { 7, 4, "High-speed kitchen blender", "Blender", 89.99m, 3000 },
                    { 8, 4, "Programmable coffee machine", "Coffee Maker", 59.99m, 4000 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "DateAdded", "ProductID", "Quantity", "UserID" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 5, 12, 15, 0, 0, 0, DateTimeKind.Local), 5, 2, 2 },
                    { 3, new DateTime(2025, 5, 13, 18, 0, 0, 0, DateTimeKind.Local), 6, 1, 3 },
                    { 4, new DateTime(2025, 5, 14, 12, 0, 0, 0, DateTimeKind.Local), 7, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 5, 3, 1, 1 },
                    { 6, 3, 7, 1 },
                    { 7, 4, 5, 3 },
                    { 8, 4, 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "AdminIbnAdmin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "UserIbnUser");
        }
    }
}
