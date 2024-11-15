using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientSalesRegistry.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerAndProductSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailType",
                table: "Customer",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailType",
                table: "Customer");
        }
    }
}
