using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_stock_market.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_ceo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_turnover = table.Column<long>(type: "bigint", nullable: false),
                    Company_website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_code);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ref_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock_prize = table.Column<float>(type: "real", nullable: false),
                    Date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Company_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ref_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
