using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => new { x.MenuId, x.Id });
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
                    GroupMenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => new { x.GroupMenuId, x.GroupId, x.Id });
                    table.ForeignKey(
                        name: "FK_Items_Groups_GroupMenuId_GroupId",
                        columns: x => new { x.GroupMenuId, x.GroupId },
                        principalSchema: "menus",
                        principalTable: "Groups",
                        principalColumns: new[] { "MenuId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
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
