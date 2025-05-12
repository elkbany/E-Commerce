using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DA.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECtJWIRqgoBEDzcFOu4Kz0LCY/MSge+0SZns5va/p5u6Gg4O87dz1beHha+iyFbsHA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBHDiyLRTxpFa9qgoSrzKlEMb2TQjBd1itcvuGrwgvtx80k7zeKga6KPH7+QO+522w==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFrg5xB2kQ0uJ6n5sQ8iQ4e7jF0vP3K8L2N9mXy1Q3wZ7vA8pK5mL4oP6nR8sT9uQw ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: " AQAAAAIAAYagAAAAEKj8mN3pR4tL5oQ9sP7iX2c8jD0vQ6k3L1M8nXy2Q4wZ8vB9pK6nL5oP7nR9sT0uQw ==");
        }
    }
}
