using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class foodsresta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_RestaurantFoods_RestaurantFoodsId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropTable(
                name: "FoodRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_Foods_RestaurantFoodsId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RestaurantFoodsId",
                table: "Foods");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "RestaurantFoods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "RestaurantFoods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_FoodId",
                table: "RestaurantFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Foods_FoodId",
                table: "RestaurantFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Foods_FoodId",
                table: "RestaurantFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantFoods_FoodId",
                table: "RestaurantFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "RestaurantFoods");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "RestaurantFoods",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantFoodsId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodRestaurant",
                columns: table => new
                {
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    foodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRestaurant", x => new { x.RestaurantsId, x.foodsId });
                    table.ForeignKey(
                        name: "FK_FoodRestaurant_Foods_foodsId",
                        column: x => x.foodsId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantFoodsId",
                table: "Foods",
                column: "RestaurantFoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestaurant_foodsId",
                table: "FoodRestaurant",
                column: "foodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_RestaurantFoods_RestaurantFoodsId",
                table: "Foods",
                column: "RestaurantFoodsId",
                principalTable: "RestaurantFoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
