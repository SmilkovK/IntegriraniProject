using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAppRepository.Migrations
{
    /// <inheritdoc />
    public partial class finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCarts_AspNetUsers_OwnerId",
                table: "FoodCarts");

            migrationBuilder.DropIndex(
                name: "IX_FoodCarts_OwnerId",
                table: "FoodCarts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "FoodCarts");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "FoodCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                table: "FoodCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OrderOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderOrders_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodsInOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodsInOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodsInOrders_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodsInOrders_OrderOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCarts_FoodId",
                table: "FoodCarts",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCarts_ShoppingCartId",
                table: "FoodCarts",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodsInOrders_FoodId",
                table: "FoodsInOrders",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodsInOrders_OrderId",
                table: "FoodsInOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrders_OwnerId",
                table: "OrderOrders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OwnerId",
                table: "ShoppingCarts",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCarts_Foods_FoodId",
                table: "FoodCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCarts_ShoppingCarts_ShoppingCartId",
                table: "FoodCarts");

            migrationBuilder.DropTable(
                name: "FoodsInOrders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodCarts_FoodId",
                table: "FoodCarts");

            migrationBuilder.DropIndex(
                name: "IX_FoodCarts_ShoppingCartId",
                table: "FoodCarts");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "FoodCarts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodCarts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "FoodCarts");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "FoodCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCarts_OwnerId",
                table: "FoodCarts",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCarts_AspNetUsers_OwnerId",
                table: "FoodCarts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
