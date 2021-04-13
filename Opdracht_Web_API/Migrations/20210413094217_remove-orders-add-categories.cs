using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opdracht_Web_API.Migrations
{
    public partial class removeordersaddcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStoreItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    TaxLevelId = table.Column<int>(type: "int", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Taxes_TaxLevelId",
                        column: x => x.TaxLevelId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lamps" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kitchen" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Cleaning" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "AmountInStock", "BuyPrice", "CategoryId", "Code", "Name", "TaxLevelId" },
                values: new object[,]
                {
                    { 1, true, 100, 2.0, 1, "L0001", "Lamp", 1 },
                    { 2, true, 35, 20.0, 2, "E0001", "Toaster", 1 },
                    { 3, true, 10, 150.0, 2, "E0002", "Refrigerator", 1 },
                    { 6, false, 30, 15.0, 2, "E0005", "Mixer", 1 },
                    { 9, true, 25, 250.0, 2, "E0007", "Food processor", 1 },
                    { 4, true, 10, 200.0, 3, "E0003", "Washing machine", 1 },
                    { 5, false, 10, 200.0, 3, "E0004", "Dishwasher", 1 },
                    { 7, true, 40, 100.0, 3, "E0006", "Iron", 1 },
                    { 8, true, 20, 20.0, 3, "H0001", "Ironing board", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxLevelId",
                table: "Products",
                column: "TaxLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreItems_Taxes_TaxLevelId",
                        column: x => x.TaxLevelId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStoreItem",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStoreItem", x => new { x.CartId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderStoreItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStoreItem_StoreItems_CartId",
                        column: x => x.CartId,
                        principalTable: "StoreItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StoreItems",
                columns: new[] { "Id", "Active", "AmountInStock", "BuyPrice", "Code", "Name", "TaxLevelId" },
                values: new object[,]
                {
                    { 1, true, 100, 2.0, "L0001", "Lamp", 1 },
                    { 2, true, 35, 20.0, "E0001", "Broodrooster", 1 },
                    { 3, true, 10, 150.0, "E0002", "Koelkast", 1 },
                    { 4, true, 10, 200.0, "E0003", "Wasmachine", 1 },
                    { 5, true, 10, 200.0, "E0004", "Vaatwasmachine", 1 },
                    { 6, true, 30, 15.0, "E0005", "Mixer", 1 },
                    { 7, true, 40, 100.0, "E0006", "Strijkijzer", 1 },
                    { 8, true, 20, 20.0, "H0001", "Strijkplank", 1 },
                    { 9, true, 25, 250.0, "E0007", "Keukenrobot", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStoreItem_OrdersId",
                table: "OrderStoreItem",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_TaxLevelId",
                table: "StoreItems",
                column: "TaxLevelId");
        }
    }
}
