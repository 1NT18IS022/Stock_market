using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_stock_market.Migrations
{
    /// <inheritdoc />
    public partial class stockpriceedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_prize",
                table: "Stocks",
                newName: "Stock_price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_price",
                table: "Stocks",
                newName: "Stock_prize");
        }
    }
}
