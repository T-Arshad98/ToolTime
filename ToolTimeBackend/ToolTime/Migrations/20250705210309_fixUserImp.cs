using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class fixUserImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MaintenanceRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CheckoutRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutRecords_UserId",
                table: "CheckoutRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutRecords_Users_UserId",
                table: "CheckoutRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Users_UserId",
                table: "MaintenanceRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutRecords_Users_UserId",
                table: "CheckoutRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Users_UserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutRecords_UserId",
                table: "CheckoutRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MaintenanceRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CheckoutRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
