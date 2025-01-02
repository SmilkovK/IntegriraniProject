using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class fixf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddFoodViewModelId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddFoodViewModelId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddFoodViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedRestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedFoodIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddFoodViewModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_AddFoodViewModelId",
                table: "Restaurants",
                column: "AddFoodViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_AddFoodViewModelId",
                table: "Foods",
                column: "AddFoodViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AddFoodViewModels_AddFoodViewModelId",
                table: "Foods",
                column: "AddFoodViewModelId",
                principalTable: "AddFoodViewModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AddFoodViewModels_AddFoodViewModelId",
                table: "Restaurants",
                column: "AddFoodViewModelId",
                principalTable: "AddFoodViewModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AddFoodViewModels_AddFoodViewModelId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AddFoodViewModels_AddFoodViewModelId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "AddFoodViewModels");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_AddFoodViewModelId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Foods_AddFoodViewModelId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "AddFoodViewModelId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "AddFoodViewModelId",
                table: "Foods");
        }
    }
}
