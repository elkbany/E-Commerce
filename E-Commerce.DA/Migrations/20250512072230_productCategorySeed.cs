using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class productCategorySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets", "Electronics" },
                    { 2, "Apparel and accessories", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone", "Smartphone", 699.99m, 5000 },
                    { 2, 2, "Cotton casual t-shirt", "T-Shirt", 19.99m, 7500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
