using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class foodsrestatest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantFoods_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropColumn(
                name: "SelectedFoodIds",
                table: "RestaurantFoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods",
                columns: new[] { "RestaurantId", "FoodId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods");

            migrationBuilder.AddColumn<string>(
                name: "SelectedFoodIds",
                table: "RestaurantFoods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId");
        }
    }
}
