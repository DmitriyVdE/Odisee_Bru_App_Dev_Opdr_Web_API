using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opdracht_Web_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    TaxLevelId = table.Column<int>(type: "int", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
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
                table: "Taxes",
                columns: new[] { "Id", "Name", "TaxPercentage" },
                values: new object[] { 1, "standard", 21 });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "Name", "TaxPercentage" },
                values: new object[] { 2, "exceptions and meals", 12 });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "Name", "TaxPercentage" },
                values: new object[] { 3, "basic", 6 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStoreItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
