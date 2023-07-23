using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_stock_market.Migrations
{
    /// <inheritdoc />
    public partial class drop_company_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company_code",
                table: "Companies",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Company_code");
        }
    }
}
