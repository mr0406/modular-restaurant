using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.EF.Migrations
{
    public partial class AddItemDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "menus",
                table: "Items",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "menus",
                table: "Items");
        }
    }
}
