using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderViewer.Service.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("b69d2fa7-68a3-4f09-92c4-a4b1a32633ab"));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Customer", "Status", "Total" },
                values: new object[] { new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"), new DateTime(2025, 8, 15, 14, 17, 5, 41, DateTimeKind.Utc).AddTicks(291), "Lewis Hamilton ", 0, 10000.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("3c085b93-d7bf-4d74-a386-b9f0e91495a3"), "Keyboard", new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"), 2, 500m },
                    { new Guid("6aa19957-fcf2-4bb7-8db9-7e77575a4669"), "Laptop", new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"), 1, 8500m },
                    { new Guid("7c01a8d2-3fca-4969-8b8f-aa7475e03d36"), "Mouse", new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"), 2, 250m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Customer", "Status", "Total" },
                values: new object[] { new Guid("b69d2fa7-68a3-4f09-92c4-a4b1a32633ab"), new DateTime(2025, 7, 27, 12, 14, 46, 148, DateTimeKind.Utc).AddTicks(8620), "John Doe", 0, 100.00m });
        }
    }
}
