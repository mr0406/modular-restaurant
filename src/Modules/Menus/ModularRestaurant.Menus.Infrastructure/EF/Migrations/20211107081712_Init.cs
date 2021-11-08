using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "menus");

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalName = table.Column<string>(type: "text", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "menus",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "menus",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MenuId",
                schema: "menus",
                table: "Groups",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GroupId",
                schema: "menus",
                table: "Items",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items",
                schema: "menus");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "menus");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "menus");
        }
    }
}
