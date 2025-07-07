using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Description", "LastInspectionDate", "Name", "SerialNumber", "Type" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 6, 25, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3503), "Makita Hammer Drill", "SN12345", "Drill" },
                    { 2, null, new DateTime(2025, 6, 30, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3512), "Bosch Circular Saw", "SN98765", "Saw" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { "admin001", "Bill", "Wriley", "Admin" },
                    { "johndoe123", "John", "Doe", "User" }
                });

            migrationBuilder.InsertData(
                table: "CheckoutRecords",
                columns: new[] { "Id", "ActualReturn", "CheckoutDateTime", "ExpectedReturnDateTime", "ToolId", "UserId" },
                values: new object[] { 1, null, new DateTime(2025, 7, 3, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3530), new DateTime(2025, 7, 10, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3532), 1, "johndoe123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin001");

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "johndoe123");
        }
    }
}
