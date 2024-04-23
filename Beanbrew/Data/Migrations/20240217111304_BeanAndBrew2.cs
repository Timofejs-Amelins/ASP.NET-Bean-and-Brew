using Microsoft.EntityFrameworkCore.Migrations;

namespace Beanbrew.Data.Migrations
{
    public partial class BeanAndBrew2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "BakedGood",
                columns: table => new
                {
                    BakedGoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakedGoodName = table.Column<string>(nullable: true),
                    BakedGoodType = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_BakedGood", x => x.BakedGoodsId);
                });

            _ = migrationBuilder.CreateTable(
                name: "Hamper",
                columns: table => new
                {
                    HamperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Hamper", x => x.HamperId);
                });

            _ = migrationBuilder.CreateTable(
                name: "BakedGoodsOrder",
                columns: table => new
                {
                    BakedGoodsOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CustomersCustomerId = table.Column<int>(nullable: true),
                    HampersHamperId = table.Column<int>(nullable: true),
                    BakedGoodsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_BakedGoodsOrder", x => x.BakedGoodsOrderId);
                    _ = table.ForeignKey(
                        name: "FK_BakedGoodsOrder_BakedGood_BakedGoodsId",
                        column: x => x.BakedGoodsId,
                        principalTable: "BakedGood",
                        principalColumn: "BakedGoodsId",
                        onDelete: ReferentialAction.Restrict);
                    _ = table.ForeignKey(
                        name: "FK_BakedGoodsOrder_Customer_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    _ = table.ForeignKey(
                        name: "FK_BakedGoodsOrder_Hamper_HampersHamperId",
                        column: x => x.HampersHamperId,
                        principalTable: "Hamper",
                        principalColumn: "HamperId",
                        onDelete: ReferentialAction.Restrict);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_BakedGoodsId",
                table: "BakedGoodsOrder",
                column: "BakedGoodsId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_CustomersCustomerId",
                table: "BakedGoodsOrder",
                column: "CustomersCustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_BakedGoodsOrder_HampersHamperId",
                table: "BakedGoodsOrder",
                column: "HampersHamperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "BakedGoodsOrder");

            _ = migrationBuilder.DropTable(
                name: "BakedGood");

            _ = migrationBuilder.DropTable(
                name: "Hamper");
        }
    }
}
