using Microsoft.EntityFrameworkCore.Migrations;

namespace Help.Migrations
{
    public partial class databaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cities_CityId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cuisines_CuisineId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Prices_PriceId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CuisineId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cities_CityId",
                table: "CityCuisinePriceRestaurants",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cuisines_CuisineId",
                table: "CityCuisinePriceRestaurants",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Prices_PriceId",
                table: "CityCuisinePriceRestaurants",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cities_CityId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cuisines_CuisineId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Prices_PriceId",
                table: "CityCuisinePriceRestaurants");

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CuisineId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "CityCuisinePriceRestaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cities_CityId",
                table: "CityCuisinePriceRestaurants",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Cuisines_CuisineId",
                table: "CityCuisinePriceRestaurants",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCuisinePriceRestaurants_Prices_PriceId",
                table: "CityCuisinePriceRestaurants",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
