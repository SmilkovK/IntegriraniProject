using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class failss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInCarts_Foods_FoodId",
                table: "FoodsInCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInCarts_ShoppingCarts_ShoppingCartId",
                table: "FoodsInCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsInCarts",
                table: "FoodsInCarts");

            migrationBuilder.RenameTable(
                name: "FoodsInCarts",
                newName: "FoodsInCart");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCarts_ShoppingCartId",
                table: "FoodsInCart",
                newName: "IX_FoodsInCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCarts_FoodId",
                table: "FoodsInCart",
                newName: "IX_FoodsInCart_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodsInCart",
                table: "FoodsInCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInCart_Foods_FoodId",
                table: "FoodsInCart",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInCart_ShoppingCarts_ShoppingCartId",
                table: "FoodsInCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInCart_Foods_FoodId",
                table: "FoodsInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInCart_ShoppingCarts_ShoppingCartId",
                table: "FoodsInCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsInCart",
                table: "FoodsInCart");

            migrationBuilder.RenameTable(
                name: "FoodsInCart",
                newName: "FoodsInCarts");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCart_ShoppingCartId",
                table: "FoodsInCarts",
                newName: "IX_FoodsInCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCart_FoodId",
                table: "FoodsInCarts",
                newName: "IX_FoodsInCarts_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodsInCarts",
                table: "FoodsInCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInCarts_Foods_FoodId",
                table: "FoodsInCarts",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInCarts_ShoppingCarts_ShoppingCartId",
                table: "FoodsInCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
