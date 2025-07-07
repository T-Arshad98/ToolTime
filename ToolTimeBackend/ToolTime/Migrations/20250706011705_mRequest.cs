using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class mRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1189), new DateTime(2025, 7, 11, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1211), new DateTime(2025, 7, 1, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 26, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastInspectionDate",
                value: new DateTime(2025, 7, 1, 1, 17, 4, 744, DateTimeKind.Utc).AddTicks(1170));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2813), new DateTime(2025, 7, 11, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2833), new DateTime(2025, 7, 1, 1, 10, 30, 504, DateTimeKind.Utc).AddTicks(2833) });

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
    }
}
