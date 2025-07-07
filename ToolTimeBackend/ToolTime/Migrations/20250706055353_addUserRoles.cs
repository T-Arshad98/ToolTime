using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class addUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                columns: new[] { "UserId", "RoleName" });

            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4429), new DateTime(2025, 7, 11, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4487), new DateTime(2025, 7, 1, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 26, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastInspectionDate",
                value: new DateTime(2025, 7, 1, 5, 53, 52, 802, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "UserRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "UserId", "RoleName" });

            migrationBuilder.UpdateData(
                table: "CheckoutRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckoutDateTime", "ExpectedReturnDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9212), new DateTime(2025, 7, 11, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "MaintenanceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2025, 6, 26, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9236), new DateTime(2025, 7, 1, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastInspectionDate",
                value: new DateTime(2025, 6, 26, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastInspectionDate",
                value: new DateTime(2025, 7, 1, 3, 34, 6, 367, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
