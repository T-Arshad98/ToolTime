using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class mRequestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2813), new DateTime(2025, 7, 11, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "Id", "CreatedAt", "IssueDesc", "ResolvedAt", "Status", "ToolId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 3, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2830), "Battery not charging properly", null, "Open", 1, "johndoe123" },
                    { 2, new DateTime(2025, 6, 26, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2833), "Blade guard is loose", new DateTime(2025, 7, 1, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2833), "Resolved", 2, "johndoe123" }
                });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 26, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastInspectionDate",
                value: new DateTime(2025, 7, 1, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2795));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 3, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3530), new DateTime(2025, 7, 10, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 25, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 30, 21, 13, 34, 287, DateTimeKind.Utc).AddTicks(3512));
        }
    }
}
