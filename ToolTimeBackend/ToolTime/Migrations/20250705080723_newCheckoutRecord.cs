using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class newCheckoutRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckoutRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TooldId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReturnDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutRecords_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutRecords_ToolId",
                table: "CheckoutRecords",
                column: "ToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutRecords");
        }
    }
}
