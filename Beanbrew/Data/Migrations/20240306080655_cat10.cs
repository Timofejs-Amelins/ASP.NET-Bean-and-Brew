using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Beanbrew.Data.Migrations
{
    public partial class cat10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Contact", x => x.ContactID);
                });

            _ = migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Restaurant", x => x.RestaurantId);
                });

            _ = migrationBuilder.CreateTable(
                name: "SpaceBooking",
                columns: table => new
                {
                    SpaceBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false),
                    TimeSlot = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_SpaceBooking", x => x.SpaceBookingId);
                    _ = table.ForeignKey(
                        name: "FK_SpaceBooking_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SpaceBooking_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_SpaceBooking_CustomerId",
                table: "SpaceBooking",
                column: "CustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SpaceBooking_RestaurantId",
                table: "SpaceBooking",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "Contact");

            _ = migrationBuilder.DropTable(
                name: "SpaceBooking");

            _ = migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
