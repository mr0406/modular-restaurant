using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.EF.Migrations
{
    public partial class AddItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceCurrency",
                schema: "menus",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceValue",
                schema: "menus",
                table: "Items",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceCurrency",
                schema: "menus",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PriceValue",
                schema: "menus",
                table: "Items");
        }
    }
}
