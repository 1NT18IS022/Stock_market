using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_stock_market.Migrations
{
    /// <inheritdoc />
    public partial class add_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "CD",
                columns: table => new
                {
                    Company_code = table.Column<int>(type: "int", nullable: false),
                    Company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_ceo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_turnover = table.Column<long>(type: "bigint", nullable: false),
                    Company_website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CD", x => x.Company_code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CD");

            
        }
    }
}
