using Microsoft.EntityFrameworkCore.Migrations;

namespace Food.EntityFramework.Migrations
{
    public partial class AddMenuColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "OrderDish",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuStatus",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish");

            migrationBuilder.DropColumn(
                name: "MenuStatus",
                table: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "OrderDish",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
