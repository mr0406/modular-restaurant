using Microsoft.EntityFrameworkCore.Migrations;

namespace ModularRestaurant.Menus.Infrastructure.Migrations
{
    public partial class Change_Table_Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Menus_MenuId",
                schema: "menus",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Group_GroupMenuId_GroupId",
                schema: "menus",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "menus",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                schema: "menus",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Item",
                schema: "menus",
                newName: "Items",
                newSchema: "menus");

            migrationBuilder.RenameTable(
                name: "Group",
                schema: "menus",
                newName: "Groups",
                newSchema: "menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                schema: "menus",
                table: "Items",
                columns: new[] { "GroupMenuId", "GroupId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                schema: "menus",
                table: "Groups",
                columns: new[] { "MenuId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Menus_MenuId",
                schema: "menus",
                table: "Groups",
                column: "MenuId",
                principalSchema: "menus",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Groups_GroupMenuId_GroupId",
                schema: "menus",
                table: "Items",
                columns: new[] { "GroupMenuId", "GroupId" },
                principalSchema: "menus",
                principalTable: "Groups",
                principalColumns: new[] { "MenuId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Menus_MenuId",
                schema: "menus",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Groups_GroupMenuId_GroupId",
                schema: "menus",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                schema: "menus",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                schema: "menus",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Items",
                schema: "menus",
                newName: "Item",
                newSchema: "menus");

            migrationBuilder.RenameTable(
                name: "Groups",
                schema: "menus",
                newName: "Group",
                newSchema: "menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "menus",
                table: "Item",
                columns: new[] { "GroupMenuId", "GroupId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                schema: "menus",
                table: "Group",
                columns: new[] { "MenuId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Menus_MenuId",
                schema: "menus",
                table: "Group",
                column: "MenuId",
                principalSchema: "menus",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Group_GroupMenuId_GroupId",
                schema: "menus",
                table: "Item",
                columns: new[] { "GroupMenuId", "GroupId" },
                principalSchema: "menus",
                principalTable: "Group",
                principalColumns: new[] { "MenuId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
