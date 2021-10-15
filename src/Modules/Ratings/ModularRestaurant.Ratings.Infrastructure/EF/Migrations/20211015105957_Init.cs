using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ratings");

            migrationBuilder.CreateTable(
                name: "Restaurants",
                schema: "ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRating",
                schema: "ratings",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantReply = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRating", x => new { x.RestaurantId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserRating_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "ratings",
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRating",
                schema: "ratings");

            migrationBuilder.DropTable(
                name: "Restaurants",
                schema: "ratings");
        }
    }
}
