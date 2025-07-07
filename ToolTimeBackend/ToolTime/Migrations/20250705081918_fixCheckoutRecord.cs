using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolTime.Migrations
{
    /// <inheritdoc />
    public partial class fixCheckoutRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TooldId",
                table: "CheckoutRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TooldId",
                table: "CheckoutRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
