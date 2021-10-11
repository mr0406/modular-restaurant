using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => new { x.MenuId, x.Id });
                    table.ForeignKey(
                        name: "FK_Group_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "menus",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "menus",
                columns: table => new
                {
                    GroupMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => new { x.GroupMenuId, x.GroupId, x.Id });
                    table.ForeignKey(
                        name: "FK_Item_Group_GroupMenuId_GroupId",
                        columns: x => new { x.GroupMenuId, x.GroupId },
                        principalSchema: "menus",
                        principalTable: "Group",
                        principalColumns: new[] { "MenuId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "menus");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "menus");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "menus");
        }
    }
}
