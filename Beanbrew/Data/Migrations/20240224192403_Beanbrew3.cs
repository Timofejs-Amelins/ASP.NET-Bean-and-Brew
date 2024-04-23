using Microsoft.EntityFrameworkCore.Migrations;

namespace Beanbrew.Data.Migrations
{
    public partial class Beanbrew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_BakedGood_BakedGoodsId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_Customer_CustomersCustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_Hamper_HampersHamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropIndex(
                name: "IX_BakedGoodsOrder_CustomersCustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropIndex(
                name: "IX_BakedGoodsOrder_HampersHamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropColumn(
                name: "CustomersCustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropColumn(
                name: "HampersHamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Hamper",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            _ = migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Hamper",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            _ = migrationBuilder.AlterColumn<int>(
                name: "BakedGoodsId",
                table: "BakedGoodsOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            _ = migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "BakedGoodsOrder",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AddColumn<int>(
                name: "HamperId",
                table: "BakedGoodsOrder",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_CustomerId",
                table: "BakedGoodsOrder",
                column: "CustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_HamperId",
                table: "BakedGoodsOrder",
                column: "HamperId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_BakedGood_BakedGoodsId",
                table: "BakedGoodsOrder",
                column: "BakedGoodsId",
                principalTable: "BakedGood",
                principalColumn: "BakedGoodsId",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_Customer_CustomerId",
                table: "BakedGoodsOrder",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_Hamper_HamperId",
                table: "BakedGoodsOrder",
                column: "HamperId",
                principalTable: "Hamper",
                principalColumn: "HamperId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_BakedGood_BakedGoodsId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_Customer_CustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_BakedGoodsOrder_Hamper_HamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropIndex(
                name: "IX_BakedGoodsOrder_CustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropIndex(
                name: "IX_BakedGoodsOrder_HamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.DropColumn(
                name: "HamperId",
                table: "BakedGoodsOrder");

            _ = migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Hamper",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            _ = migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Hamper",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            _ = migrationBuilder.AlterColumn<int>(
                name: "BakedGoodsId",
                table: "BakedGoodsOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            _ = migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerId",
                table: "BakedGoodsOrder",
                type: "int",
                nullable: true);

            _ = migrationBuilder.AddColumn<int>(
                name: "HampersHamperId",
                table: "BakedGoodsOrder",
                type: "int",
                nullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_CustomersCustomerId",
                table: "BakedGoodsOrder",
                column: "CustomersCustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_HampersHamperId",
                table: "BakedGoodsOrder",
                column: "HampersHamperId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_BakedGood_BakedGoodsId",
                table: "BakedGoodsOrder",
                column: "BakedGoodsId",
                principalTable: "BakedGood",
                principalColumn: "BakedGoodsId",
                onDelete: ReferentialAction.Restrict);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_Customer_CustomersCustomerId",
                table: "BakedGoodsOrder",
                column: "CustomersCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_BakedGoodsOrder_Hamper_HampersHamperId",
                table: "BakedGoodsOrder",
                column: "HampersHamperId",
                principalTable: "Hamper",
                principalColumn: "HamperId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
