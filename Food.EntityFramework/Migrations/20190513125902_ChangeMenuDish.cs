using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.EntityFramework.Migrations
{
    public partial class ChangeMenuDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuDish",
                table: "MenuDish");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MenuDish",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuDish",
                table: "MenuDish",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDish_MenuId",
                table: "MenuDish",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuDish",
                table: "MenuDish");

            migrationBuilder.DropIndex(
                name: "IX_MenuDish_MenuId",
                table: "MenuDish");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenuDish");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuDish",
                table: "MenuDish",
                columns: new[] { "MenuId", "DishId" });
        }
    }
}
