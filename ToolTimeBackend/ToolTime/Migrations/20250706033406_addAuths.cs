using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class addAuths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "admin001");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "johndoe123");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleName });
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { "u1", "admin123", "admin" },
                    { "u10", "dev123", "dev" },
                    { "u11", "qa123", "qa" },
                    { "u12", "view123", "viewer" },
                    { "u13", "super123", "superadmin" },
                    { "u14", "readonly123", "readonly" },
                    { "u15", "hybrid123", "hybriduser" },
                    { "u2", "manager123", "manager" },
                    { "u3", "tech123", "tech1" },
                    { "u4", "tech123", "tech2" },
                    { "u5", "user123", "user1" },
                    { "u6", "user123", "user2" },
                    { "u7", "user123", "user3" },
                    { "u8", "john123", "john" },
                    { "u9", "jane123", "jane" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleName", "UserId" },
                values: new object[,]
                {
                    { "Admin", "u1" },
                    { "Admin", "u10" },
                    { "Developer", "u10" },
                    { "QA", "u11" },
                    { "Viewer", "u12" },
                    { "Admin", "u13" },
                    { "Manager", "u13" },
                    { "Technician", "u13" },
                    { "ReadOnly", "u14" },
                    { "Manager", "u15" },
                    { "User", "u15" },
                    { "Manager", "u2" },
                    { "Technician", "u3" },
                    { "Technician", "u4" },
                    { "User", "u5" },
                    { "User", "u6" },
                    { "User", "u7" },
                    { "Technician", "u8" },
                    { "User", "u8" },
                    { "Manager", "u9" },
                    { "User", "u9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u10");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u11");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u12");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u13");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u14");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u15");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u8");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u9");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { "admin001", "Bill", "Wriley", "Admin" },
                    { "johndoe123", "John", "Doe", "User" }
                });
        }
    }
}
