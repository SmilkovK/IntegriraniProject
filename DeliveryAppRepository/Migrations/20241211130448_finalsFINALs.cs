using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class finalsFINALs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCarts_Foods_FoodId",
                table: "FoodCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCarts_ShoppingCarts_ShoppingCartId",
                table: "FoodCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInOrders_OrderOrders_OrderId",
                table: "FoodsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderOrders_AspNetUsers_OwnerId",
                table: "OrderOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderOrders",
                table: "OrderOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodCarts",
                table: "FoodCarts");

            migrationBuilder.RenameTable(
                name: "OrderOrders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "FoodCarts",
                newName: "FoodsInCart");

            migrationBuilder.RenameIndex(
                name: "IX_OrderOrders_OwnerId",
                table: "Orders",
                newName: "IX_Orders_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCarts_ShoppingCartId",
                table: "FoodsInCart",
                newName: "IX_FoodsInCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCarts_FoodId",
                table: "FoodsInCart",
                newName: "IX_FoodsInCart_FoodId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInOrders_Orders_OrderId",
                table: "FoodsInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsInOrders_Orders_OrderId",
                table: "FoodsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsInCart",
                table: "FoodsInCart");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderOrders");

            migrationBuilder.RenameTable(
                name: "FoodsInCart",
                newName: "FoodCarts");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OwnerId",
                table: "OrderOrders",
                newName: "IX_OrderOrders_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCart_ShoppingCartId",
                table: "FoodCarts",
                newName: "IX_FoodCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsInCart_FoodId",
                table: "FoodCarts",
                newName: "IX_FoodCarts_FoodId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderOrders",
                table: "OrderOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodCarts",
                table: "FoodCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCarts_Foods_FoodId",
                table: "FoodCarts",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCarts_ShoppingCarts_ShoppingCartId",
                table: "FoodCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsInOrders_OrderOrders_OrderId",
                table: "FoodsInOrders",
                column: "OrderId",
                principalTable: "OrderOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderOrders_AspNetUsers_OwnerId",
                table: "OrderOrders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
