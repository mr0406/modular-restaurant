using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.EF.Migrations
{
    public partial class AddVersioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "menus",
                table: "Menus",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "menus",
                table: "Menus");
        }
    }
}
