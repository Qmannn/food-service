using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.EntityFramework.Migrations
{
    public partial class AddMenuStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuStatus",
                table: "Menu",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuStatus",
                table: "Menu");
        }
    }
}
