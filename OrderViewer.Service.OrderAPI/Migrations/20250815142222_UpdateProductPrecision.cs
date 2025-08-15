using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderViewer.Service.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3c085b93-d7bf-4d74-a386-b9f0e91495a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6aa19957-fcf2-4bb7-8db9-7e77575a4669"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7c01a8d2-3fca-4969-8b8f-aa7475e03d36"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("006d2937-8811-47dd-b15e-33f2bcf78bf0"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
