using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Beanbrew.Data.Migrations
{
    public partial class BeanBrew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeName = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Coffee", x => x.CoffeeId);
                });

            _ = migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            _ = migrationBuilder.CreateTable(
                name: "CoffeeOrder",
                columns: table => new
                {
                    CoffeeOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CoffeeOrder", x => x.CoffeeOrderId);
                    _ = table.ForeignKey(
                        name: "FK_CoffeeOrder_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_CoffeeOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_CoffeeOrder_CoffeeId",
                table: "CoffeeOrder",
                column: "CoffeeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CoffeeOrder_CustomerId",
                table: "CoffeeOrder",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "CoffeeOrder");

            _ = migrationBuilder.DropTable(
                name: "Coffee");

            _ = migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
