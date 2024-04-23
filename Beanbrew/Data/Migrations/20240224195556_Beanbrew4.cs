using Microsoft.EntityFrameworkCore.Migrations;

namespace Beanbrew.Data.Migrations
{
    public partial class Beanbrew4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Hamper",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            _ = migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Hamper",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Hamper",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            _ = migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Hamper",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
