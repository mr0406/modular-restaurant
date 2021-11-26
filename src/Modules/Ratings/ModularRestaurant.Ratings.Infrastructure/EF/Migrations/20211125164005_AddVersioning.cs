using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Migrations
{
    public partial class AddVersioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "ratings",
                table: "UserRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "ratings",
                table: "UserRatings");
        }
    }
}
