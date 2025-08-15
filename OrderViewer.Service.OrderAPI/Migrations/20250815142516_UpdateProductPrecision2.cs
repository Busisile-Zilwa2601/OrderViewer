using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderViewer.Service.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductPrecision2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("58ca1033-e6e1-4a92-bb64-97624b66044e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e07d5ae8-6a80-4c24-9b8d-a1a63bc3d945"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f4d3e8c6-5dfd-49d7-b9fb-dd511557949e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("92ce28bd-2740-4e8a-ae93-723292301c2d"));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Customer", "Status", "Total" },
                values: new object[] { new Guid("ea380f5a-59e8-42a8-8dde-4504bb2e0ab0"), new DateTime(2025, 8, 15, 14, 25, 16, 260, DateTimeKind.Utc).AddTicks(1359), "Lewis Hamilton ", 0, 10000.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("54b92b29-2652-427a-9a28-36623afc393d"), "Mouse", new Guid("ea380f5a-59e8-42a8-8dde-4504bb2e0ab0"), 2, 250m },
                    { new Guid("7d44223c-2f17-4ca6-aeaa-3d9b4f56311d"), "Laptop", new Guid("ea380f5a-59e8-42a8-8dde-4504bb2e0ab0"), 1, 8500m },
                    { new Guid("bd9b617f-42ef-4e70-8bf9-dd2ea2625bab"), "Keyboard", new Guid("ea380f5a-59e8-42a8-8dde-4504bb2e0ab0"), 2, 500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("54b92b29-2652-427a-9a28-36623afc393d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7d44223c-2f17-4ca6-aeaa-3d9b4f56311d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bd9b617f-42ef-4e70-8bf9-dd2ea2625bab"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ea380f5a-59e8-42a8-8dde-4504bb2e0ab0"));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Customer", "Status", "Total" },
                values: new object[] { new Guid("92ce28bd-2740-4e8a-ae93-723292301c2d"), new DateTime(2025, 8, 15, 14, 22, 22, 66, DateTimeKind.Utc).AddTicks(118), "Lewis Hamilton ", 0, 10000.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("58ca1033-e6e1-4a92-bb64-97624b66044e"), "Mouse", new Guid("92ce28bd-2740-4e8a-ae93-723292301c2d"), 2, 250m },
                    { new Guid("e07d5ae8-6a80-4c24-9b8d-a1a63bc3d945"), "Laptop", new Guid("92ce28bd-2740-4e8a-ae93-723292301c2d"), 1, 8500m },
                    { new Guid("f4d3e8c6-5dfd-49d7-b9fb-dd511557949e"), "Keyboard", new Guid("92ce28bd-2740-4e8a-ae93-723292301c2d"), 2, 500m }
                });
        }
    }
}
