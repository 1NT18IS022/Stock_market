using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_stock_market.Migrations
{
    /// <inheritdoc />
    public partial class drop_id_and_add_company_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Company_code");

            migrationBuilder.AlterColumn<int>(
                name: "Company_code",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:None", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company_code",
                table: "Companies",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:None", "1, 1");
        }
    }
}
