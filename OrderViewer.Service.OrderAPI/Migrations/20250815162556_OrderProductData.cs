using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderViewer.Service.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("01916843-8a88-4c4f-8d52-2c3758672a6d"), new DateTime(2025, 5, 21, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7522), "Fernando Alonso", 3, 9031.19m },
                    { new Guid("02b34547-c1a4-42b4-ab37-1a799d3a5417"), new DateTime(2025, 6, 4, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7499), "Daniel Ricciardo", 1, 20940.11m },
                    { new Guid("1adf054d-b6eb-40da-915b-38cba82c5b2c"), new DateTime(2025, 5, 18, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7358), "Sebastian Vettel", 3, 14396.59m },
                    { new Guid("1cb82f7a-9a39-4ac5-962d-fb3be8b7f31e"), new DateTime(2025, 8, 4, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7176), "Fernando Alonso", 2, 13751.99m },
                    { new Guid("23447a11-9916-42dd-93e5-09fe025224e9"), new DateTime(2025, 7, 22, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7235), "Valtteri Bottas", 2, 12677.96m },
                    { new Guid("2a8aa5cc-e370-479f-88cf-199498c81410"), new DateTime(2025, 6, 18, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7281), "Daniel Ricciardo", 3, 7262.68m },
                    { new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), new DateTime(2025, 7, 23, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7630), "Lewis Hamilton", 2, 36300.46m },
                    { new Guid("2fe7525d-e8d5-42ec-8728-2d4cc86c7071"), new DateTime(2025, 5, 23, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7313), "Valtteri Bottas", 0, 1518.04m },
                    { new Guid("364c23bf-7770-4b90-87cc-4dbe51a72f80"), new DateTime(2025, 7, 26, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7443), "Banale", 2, 8742.62m },
                    { new Guid("3c90739f-80f9-4fee-aa41-7fcf1bc27551"), new DateTime(2025, 8, 10, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7507), "Sebastian Vettel", 3, 5623.90m },
                    { new Guid("40d266c7-38d2-40e9-9894-7ee7343ff16e"), new DateTime(2025, 5, 22, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7308), "Sebastian Vettel", 3, 12857.49m },
                    { new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"), new DateTime(2025, 8, 14, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7224), "Lando Norris", 2, 23394.03m },
                    { new Guid("4703c966-e97a-4ffe-97bb-922a9a9f0c2b"), new DateTime(2025, 8, 9, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7288), "Fernando Alonso", 3, 20040.70m },
                    { new Guid("4c790b96-3e71-442c-8412-b08ac983771b"), new DateTime(2025, 8, 12, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7258), "Sebastian Vettel", 3, 24447.44m },
                    { new Guid("4e17370c-655c-4024-a0fb-5ad5d41af532"), new DateTime(2025, 5, 26, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7164), "Valtteri Bottas", 0, 14735.32m },
                    { new Guid("595f3d82-1954-4398-83f5-38bb445abe6c"), new DateTime(2025, 7, 26, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7574), "Lewis Hamilton", 0, 23160.79m },
                    { new Guid("5ca258b5-6612-4f1d-84c6-05dea1c9dd44"), new DateTime(2025, 7, 1, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7347), "Banale", 2, 13790.01m },
                    { new Guid("5d6401b6-1d27-4f30-96d8-aee89ece5604"), new DateTime(2025, 7, 29, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7527), "Charles Leclerc", 1, 6046.95m },
                    { new Guid("5da8ed8e-b31c-453a-a215-479048514319"), new DateTime(2025, 6, 13, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7483), "Shaka", 1, 21755.86m },
                    { new Guid("65589077-31fa-41e3-a271-2c9af2052046"), new DateTime(2025, 7, 16, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7430), "Lando Norris", 1, 43638.81m },
                    { new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"), new DateTime(2025, 7, 6, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7554), "Shaka", 0, 36019.27m },
                    { new Guid("6d618cf9-1e32-47aa-9cad-b99990d0580d"), new DateTime(2025, 8, 4, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7328), "Sebastian Vettel", 0, 12918.53m },
                    { new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"), new DateTime(2025, 7, 25, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7364), "Lewis Hamilton", 2, 31244.21m },
                    { new Guid("722f677b-8dc1-4b8d-b527-d89388737d0a"), new DateTime(2025, 8, 5, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7171), "Banale", 0, 1489.77m },
                    { new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), new DateTime(2025, 8, 8, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7295), "Daniel Ricciardo", 2, 11859.49m },
                    { new Guid("7e4c0803-df8b-4a7d-a58a-f8a104595acb"), new DateTime(2025, 7, 25, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7533), "Sebastian Vettel", 2, 8691.16m },
                    { new Guid("7f17be03-7c57-4a02-b6ff-5d51a997d25c"), new DateTime(2025, 5, 19, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7489), "Daniel Ricciardo", 3, 26245.30m },
                    { new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"), new DateTime(2025, 7, 21, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7052), "Valtteri Bottas", 2, 17107.19m },
                    { new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"), new DateTime(2025, 6, 24, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7538), "Daniel Ricciardo", 0, 48465.24m },
                    { new Guid("8c1b2538-9008-499f-9f16-95b69960eced"), new DateTime(2025, 7, 14, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7472), "Valtteri Bottas", 0, 29375.29m },
                    { new Guid("8d04a8e4-5c06-4d30-b011-b7fe9af5bc21"), new DateTime(2025, 7, 12, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7565), "Banale", 2, 37677.62m },
                    { new Guid("8ee3859f-a583-4fd8-8a20-46b5d84a47a0"), new DateTime(2025, 6, 30, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7468), "Shaka", 1, 4219.88m },
                    { new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), new DateTime(2025, 5, 24, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7455), "Daniel Ricciardo", 0, 47071.94m },
                    { new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"), new DateTime(2025, 7, 24, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7111), "Lando Norris", 1, 26032.74m },
                    { new Guid("9f7c830b-07ec-48b9-a5c1-fd2736bfcae2"), new DateTime(2025, 7, 10, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7132), "Fernando Alonso", 1, 15462.52m },
                    { new Guid("a953969f-01bf-487f-898a-76a4ccb9df34"), new DateTime(2025, 7, 24, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7159), "Lewis Hamilton", 0, 4964.80m },
                    { new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"), new DateTime(2025, 7, 3, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7138), "Lewis Hamilton", 3, 37264.86m },
                    { new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"), new DateTime(2025, 5, 27, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7248), "Max Verstappen", 3, 29899.88m },
                    { new Guid("bdeb1778-ef64-4b65-b37b-704a0485f338"), new DateTime(2025, 5, 20, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7149), "Fernando Alonso", 1, 25587.14m },
                    { new Guid("bf4fa2bc-10e5-41ee-abdf-e49c261e3179"), new DateTime(2025, 6, 2, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7267), "Sebastian Vettel", 0, 395.70m },
                    { new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"), new DateTime(2025, 7, 11, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7317), "Max Verstappen", 2, 11141.20m },
                    { new Guid("cb51b1e5-1146-4351-837f-d5a2100ab289"), new DateTime(2025, 7, 17, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7450), "Banale", 0, 9551.34m },
                    { new Guid("cd0275d6-3d73-4164-9928-bc6e48ca36c0"), new DateTime(2025, 6, 26, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7122), "Max Verstappen", 3, 14790.15m },
                    { new Guid("cd3dfae4-336e-43a1-af13-d215fc01c27c"), new DateTime(2025, 8, 15, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7513), "Lewis Hamilton", 0, 14635.01m },
                    { new Guid("d8de140a-847e-4d42-a658-6754133b7f8d"), new DateTime(2025, 7, 29, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7240), "Lando Norris", 0, 20437.76m },
                    { new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"), new DateTime(2025, 6, 1, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7336), "Sebastian Vettel", 0, 9521.96m },
                    { new Guid("e115edaa-ea9f-4bff-babd-671ceeafe26c"), new DateTime(2025, 6, 3, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7548), "Sebastian Vettel", 0, 20846.84m },
                    { new Guid("e58fb697-c720-46ec-8405-ce077deb40af"), new DateTime(2025, 6, 17, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7218), "Banale", 0, 18578.02m },
                    { new Guid("e99ee60e-9c59-4156-95dd-cfb63a9508bf"), new DateTime(2025, 6, 16, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7354), "Lando Norris", 3, 1575.94m },
                    { new Guid("f1f5d7ec-381f-4341-bb6d-9f7001349123"), new DateTime(2025, 6, 5, 16, 25, 56, 278, DateTimeKind.Utc).AddTicks(7274), "Fernando Alonso", 0, 28484.16m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("00e3ca5b-fe6a-42dd-a0be-7b94c4befbd4"), "Monitor", new Guid("2a8aa5cc-e370-479f-88cf-199498c81410"), 2, 3631.34m },
                    { new Guid("0150adea-f338-46af-9844-565656fad216"), "Tablet", new Guid("f1f5d7ec-381f-4341-bb6d-9f7001349123"), 4, 3677.32m },
                    { new Guid("048fd49d-e684-43e4-b0fe-87a497ad6a96"), "USB Drive", new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"), 2, 2061.60m },
                    { new Guid("052c9e30-b187-4547-bf2e-3dbb1bf69f1e"), "Laptop", new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"), 4, 2265.47m },
                    { new Guid("0f303d56-f4e0-4803-a53f-7c604f5b94cf"), "Webcam", new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"), 4, 3851.60m },
                    { new Guid("133bbb3c-1ee3-4aaf-ab56-25a28e29a558"), "Mouse", new Guid("4703c966-e97a-4ffe-97bb-922a9a9f0c2b"), 2, 2905.00m },
                    { new Guid("19372f44-e4c3-4520-9404-8894d26ac1f2"), "Monitor", new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"), 2, 2577.88m },
                    { new Guid("19382867-74f7-4f07-b27d-48d4071d9eab"), "Webcam", new Guid("8ee3859f-a583-4fd8-8a20-46b5d84a47a0"), 4, 1054.97m },
                    { new Guid("197448d3-f8d3-4bdd-bfe4-486b51ed59f9"), "Smartphone", new Guid("6d618cf9-1e32-47aa-9cad-b99990d0580d"), 1, 4281.71m },
                    { new Guid("1b217691-db97-4ae7-afd8-b85ee51428ce"), "Smartphone", new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), 3, 3941.80m },
                    { new Guid("1bc24cc1-8196-4e9d-9edf-3a43ad7aecf2"), "Keyboard", new Guid("4703c966-e97a-4ffe-97bb-922a9a9f0c2b"), 2, 4123.89m },
                    { new Guid("1c0c8348-c1a7-4847-9c7f-9e076699652d"), "Laptop", new Guid("9f7c830b-07ec-48b9-a5c1-fd2736bfcae2"), 4, 3376.84m },
                    { new Guid("1c0fe3e5-d953-4911-b007-a12f5000344e"), "Printer", new Guid("cb51b1e5-1146-4351-837f-d5a2100ab289"), 2, 4775.67m },
                    { new Guid("1c174b13-3b65-4e8a-bfa0-2fa397410666"), "Keyboard", new Guid("bdeb1778-ef64-4b65-b37b-704a0485f338"), 2, 3801.29m },
                    { new Guid("1c2e2940-6e9b-4f1a-8002-f43d4a0bee0b"), "Smartphone", new Guid("23447a11-9916-42dd-93e5-09fe025224e9"), 4, 3169.49m },
                    { new Guid("1d96522e-6108-4354-b071-fbd1447a1571"), "Laptop", new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"), 1, 738.57m },
                    { new Guid("1fd28e2e-9ef7-4a82-a745-27ba6765fd89"), "Monitor", new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), 1, 1751.76m },
                    { new Guid("218e9a16-15bf-4ee0-8ccd-e9fc8bec2ad5"), "Mouse", new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"), 2, 1266.81m },
                    { new Guid("22aa67c2-222e-427a-9414-7510d785536c"), "Mouse", new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"), 1, 3743.26m },
                    { new Guid("2472af87-b377-4738-9fe4-862538cb7ba3"), "Keyboard", new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"), 1, 4064.67m },
                    { new Guid("26936997-cc09-4c26-b01d-4aa331ec244a"), "Mouse", new Guid("5ca258b5-6612-4f1d-84c6-05dea1c9dd44"), 3, 3982.09m },
                    { new Guid("290edf76-e561-4639-a856-21df5ca8f54f"), "Webcam", new Guid("8c1b2538-9008-499f-9f16-95b69960eced"), 4, 4939.99m },
                    { new Guid("2a55e60d-a352-49c1-aaba-70a34fda379a"), "Monitor", new Guid("7f17be03-7c57-4a02-b6ff-5d51a997d25c"), 1, 4234.90m },
                    { new Guid("2b752a51-0631-4c6d-b0b5-2677e8a2910c"), "Tablet", new Guid("65589077-31fa-41e3-a271-2c9af2052046"), 3, 1118.05m },
                    { new Guid("2f656480-ea6a-4f1b-9aa8-cc01e966787d"), "Smartphone", new Guid("65589077-31fa-41e3-a271-2c9af2052046"), 2, 4163.20m },
                    { new Guid("32bb8153-9b4b-4017-80d9-6ad421399ec7"), "Printer", new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"), 4, 3534.94m },
                    { new Guid("347230b1-3145-44dd-9d60-cef27f0626b3"), "Keyboard", new Guid("40d266c7-38d2-40e9-9894-7ee7343ff16e"), 3, 4285.83m },
                    { new Guid("359b5b0f-c428-4f6c-a5e3-d39b889f8cb7"), "Printer", new Guid("d8de140a-847e-4d42-a658-6754133b7f8d"), 4, 1946.98m },
                    { new Guid("35bf07a8-2127-45a6-acbf-25ed7b1e7dca"), "Headset", new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"), 3, 2694.96m },
                    { new Guid("36843148-963f-4a91-89a9-9b0ca17408e4"), "Monitor", new Guid("8c1b2538-9008-499f-9f16-95b69960eced"), 3, 700.86m },
                    { new Guid("36e3f6ea-3b42-4f4c-a68d-4282f8d775b9"), "Smartphone", new Guid("e58fb697-c720-46ec-8405-ce077deb40af"), 2, 3646.77m },
                    { new Guid("3a7f437c-d7d1-4c2b-ae88-e336f7a7c388"), "Monitor", new Guid("4c790b96-3e71-442c-8412-b08ac983771b"), 2, 2263.59m },
                    { new Guid("3bb40ad1-7ba4-4d0a-9a1d-bf26bb92946a"), "USB Drive", new Guid("6d618cf9-1e32-47aa-9cad-b99990d0580d"), 1, 392.26m },
                    { new Guid("3d5ccc4e-8931-4ff7-8180-9ad98bdf182a"), "Webcam", new Guid("65589077-31fa-41e3-a271-2c9af2052046"), 2, 4082.51m },
                    { new Guid("3e1b0f6e-a89b-4214-bf61-ccc2fe7eb8b3"), "Headset", new Guid("1cb82f7a-9a39-4ac5-962d-fb3be8b7f31e"), 1, 3971.89m },
                    { new Guid("44697429-ed59-4998-8467-48d033d27570"), "Printer", new Guid("01916843-8a88-4c4f-8d52-2c3758672a6d"), 4, 1338.49m },
                    { new Guid("47a67ae1-3518-4005-a2be-15ce15ec04bd"), "Headset", new Guid("cd0275d6-3d73-4164-9928-bc6e48ca36c0"), 3, 4607.85m },
                    { new Guid("4a7e65a6-4981-4a13-be60-4f6e65b5fdb3"), "Monitor", new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"), 2, 2275.86m },
                    { new Guid("4bd617e7-daa2-41ef-add2-e69c1d344d67"), "Tablet", new Guid("7f17be03-7c57-4a02-b6ff-5d51a997d25c"), 4, 4515.54m },
                    { new Guid("4df7df90-23e5-4685-a886-a91226de4cde"), "Headset", new Guid("65589077-31fa-41e3-a271-2c9af2052046"), 4, 4124.81m },
                    { new Guid("4ea6c1d5-95bc-410b-90de-68e5a4ed894e"), "Laptop", new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"), 3, 3832.80m },
                    { new Guid("5115a058-a8c4-4363-b2b8-eec499235b49"), "Smartphone", new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"), 3, 3564.89m },
                    { new Guid("51537ee2-6991-40c0-ae2a-4e874b3f8bc3"), "Tablet", new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"), 1, 883.47m },
                    { new Guid("5254739c-4563-40f6-b731-006bbc0b7082"), "Smartphone", new Guid("bdeb1778-ef64-4b65-b37b-704a0485f338"), 4, 1574.86m },
                    { new Guid("532f70b7-7a25-47be-b25d-14a614920098"), "Headset", new Guid("cd0275d6-3d73-4164-9928-bc6e48ca36c0"), 2, 483.30m },
                    { new Guid("54a91c02-5839-4577-a696-d5fb63266414"), "Monitor", new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"), 3, 4856.31m },
                    { new Guid("5711761c-e1e8-426e-87c4-d63ec9cd1f1a"), "Webcam", new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"), 1, 1713.72m },
                    { new Guid("5759d2d7-5974-4f92-a1c3-2a0a63485643"), "Headset", new Guid("a953969f-01bf-487f-898a-76a4ccb9df34"), 4, 1241.20m },
                    { new Guid("579439ca-7f74-449a-8bdb-fe005c8166a0"), "Keyboard", new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"), 4, 2420.94m },
                    { new Guid("59318be8-41bd-44b0-a0ad-7c90316d3010"), "Printer", new Guid("e58fb697-c720-46ec-8405-ce077deb40af"), 4, 2821.12m },
                    { new Guid("59af9d9e-db8f-4e42-b567-760d4818b3b5"), "Keyboard", new Guid("f1f5d7ec-381f-4341-bb6d-9f7001349123"), 3, 4385.36m },
                    { new Guid("59b611e4-1867-4c8a-99bb-72dab95a947b"), "Smartphone", new Guid("4c790b96-3e71-442c-8412-b08ac983771b"), 4, 1480.97m },
                    { new Guid("5b55e6fd-9d67-430a-ae9b-d12bff6ca8da"), "USB Drive", new Guid("1cb82f7a-9a39-4ac5-962d-fb3be8b7f31e"), 2, 3974.17m },
                    { new Guid("5b9a61d2-2a59-48c7-b040-55964dc1f96e"), "USB Drive", new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"), 3, 4051.11m },
                    { new Guid("5dc73627-0008-41d1-9559-054f223cd02d"), "Monitor", new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"), 4, 288.43m },
                    { new Guid("5f7668d4-37bf-4e8d-b634-4205c0e370d9"), "USB Drive", new Guid("65589077-31fa-41e3-a271-2c9af2052046"), 4, 1823.50m },
                    { new Guid("61afb093-96ec-440c-9eef-0d56c92f2af5"), "Printer", new Guid("02b34547-c1a4-42b4-ab37-1a799d3a5417"), 4, 2121.95m },
                    { new Guid("6335be91-b7f1-41a2-8460-5ed095f3da27"), "Keyboard", new Guid("3c90739f-80f9-4fee-aa41-7fcf1bc27551"), 2, 2603.29m },
                    { new Guid("643cf904-fb02-48cb-abf7-e267a4e005e2"), "Printer", new Guid("1adf054d-b6eb-40da-915b-38cba82c5b2c"), 3, 3347.77m },
                    { new Guid("65565ab1-33e2-4101-b866-0b7fb34969b5"), "Printer", new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), 3, 509.27m },
                    { new Guid("65bc4b92-6fca-480b-b124-910fd627e28a"), "Printer", new Guid("9f7c830b-07ec-48b9-a5c1-fd2736bfcae2"), 1, 1955.16m },
                    { new Guid("65d07be2-99a8-4d2e-a4ae-55612140cc4d"), "Headset", new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), 1, 1567.43m },
                    { new Guid("66ccde33-5f58-4d41-80af-9d538241f108"), "Printer", new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"), 4, 2520.35m },
                    { new Guid("6d0ece61-ff69-4b35-8a54-3fd5c10c53f2"), "Webcam", new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"), 1, 3201.72m },
                    { new Guid("6d882db3-8941-47d1-9bc7-d9419e8b6d7c"), "Laptop", new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), 4, 496.00m },
                    { new Guid("6e13d87b-98db-4087-99dc-62f5b71f4660"), "Tablet", new Guid("7e4c0803-df8b-4a7d-a58a-f8a104595acb"), 4, 2004.90m },
                    { new Guid("712744b6-5433-44b0-89d6-03a88d6d6c45"), "Mouse", new Guid("5d6401b6-1d27-4f30-96d8-aee89ece5604"), 3, 2015.65m },
                    { new Guid("713cb899-37d4-4a40-bae5-36ab58d1aa8a"), "Laptop", new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"), 4, 3179.46m },
                    { new Guid("7248e3f8-4a32-47a9-8187-8ad54fc9426f"), "Monitor", new Guid("4c790b96-3e71-442c-8412-b08ac983771b"), 3, 4005.61m },
                    { new Guid("737cb01f-f411-467e-887d-7bfe383104f0"), "Laptop", new Guid("1cb82f7a-9a39-4ac5-962d-fb3be8b7f31e"), 4, 457.94m },
                    { new Guid("746fee63-baa6-4c03-b2fe-939e120c4b5d"), "USB Drive", new Guid("7f17be03-7c57-4a02-b6ff-5d51a997d25c"), 3, 1316.08m },
                    { new Guid("84bfe5fb-7885-41f8-83c3-e6fcd3e54b6b"), "Monitor", new Guid("e99ee60e-9c59-4156-95dd-cfb63a9508bf"), 1, 1575.94m },
                    { new Guid("872ac3ab-fa4e-4c2f-98df-c0853e8c8e1d"), "Headset", new Guid("cd3dfae4-336e-43a1-af13-d215fc01c27c"), 2, 3067.24m },
                    { new Guid("8786f3c4-2373-47ae-8997-505a19f748e6"), "Monitor", new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), 2, 1491.75m },
                    { new Guid("87d75e54-6e8c-48a6-a72f-f163790cf3b7"), "USB Drive", new Guid("e115edaa-ea9f-4bff-babd-671ceeafe26c"), 3, 4504.88m },
                    { new Guid("88d52047-5278-4786-beb8-1f02dcd8d03b"), "Printer", new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"), 3, 1468.70m },
                    { new Guid("8909e007-91fd-476f-89ed-b34d3a3b0d48"), "Laptop", new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"), 4, 585.63m },
                    { new Guid("896d5323-fce9-4ae4-be73-1396ed39558c"), "Smartphone", new Guid("364c23bf-7770-4b90-87cc-4dbe51a72f80"), 1, 2748.92m },
                    { new Guid("9595927d-a7c3-421b-b61f-7206784b77d2"), "Tablet", new Guid("2fe7525d-e8d5-42ec-8728-2d4cc86c7071"), 1, 1518.04m },
                    { new Guid("96016659-cd3e-446e-858c-f92941ef957a"), "Mouse", new Guid("5ca258b5-6612-4f1d-84c6-05dea1c9dd44"), 3, 614.58m },
                    { new Guid("9625b626-9a4d-4a57-acf1-0ed6e6f6654d"), "Smartphone", new Guid("595f3d82-1954-4398-83f5-38bb445abe6c"), 4, 1878.88m },
                    { new Guid("96546b7e-9bf7-4635-9e79-7b7c81f0df47"), "Keyboard", new Guid("722f677b-8dc1-4b8d-b527-d89388737d0a"), 3, 496.59m },
                    { new Guid("96c78fa6-894d-4b3f-b428-a16212be350d"), "Headset", new Guid("4e17370c-655c-4024-a0fb-5ad5d41af532"), 4, 2800.30m },
                    { new Guid("989364c1-c9a8-4642-bd4e-a8a4f1e4479a"), "Webcam", new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"), 2, 1903.32m },
                    { new Guid("9b6fbbdd-a8d9-4ce2-9afb-9223396c61dc"), "Printer", new Guid("8d04a8e4-5c06-4d30-b011-b7fe9af5bc21"), 4, 4399.73m },
                    { new Guid("9fbc1b43-fba7-439c-9de3-36b09310d7fb"), "Tablet", new Guid("cd3dfae4-336e-43a1-af13-d215fc01c27c"), 1, 1620.53m },
                    { new Guid("a0a99057-ba0a-4bd4-8740-a66f684b3873"), "Monitor", new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), 4, 3863.48m },
                    { new Guid("a17847cd-fcbf-4e35-9bed-a010bfefe594"), "USB Drive", new Guid("364c23bf-7770-4b90-87cc-4dbe51a72f80"), 2, 2996.85m },
                    { new Guid("a2901ccf-f030-44e1-8c76-aefe106037d2"), "USB Drive", new Guid("4703c966-e97a-4ffe-97bb-922a9a9f0c2b"), 4, 1495.73m },
                    { new Guid("a607702b-32e6-41aa-8853-2e9319fbf6d7"), "Keyboard", new Guid("3c90739f-80f9-4fee-aa41-7fcf1bc27551"), 1, 417.32m },
                    { new Guid("a62563ed-5fd6-4642-af9c-7753bab6f2bc"), "Laptop", new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"), 4, 4146.37m },
                    { new Guid("ab30e394-7b7c-4ed2-9acc-d48a6bfc499f"), "Monitor", new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"), 2, 1661.16m },
                    { new Guid("abf97b42-dbac-4ed2-a4d8-c6161252bfb9"), "Smartphone", new Guid("4e17370c-655c-4024-a0fb-5ad5d41af532"), 3, 1178.04m },
                    { new Guid("af9eca7e-e89e-4867-8190-85cb3c43ad48"), "USB Drive", new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"), 3, 898.64m },
                    { new Guid("b2172cad-03ff-4ab8-aa56-f73492220ca1"), "Mouse", new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"), 1, 1847.05m },
                    { new Guid("b2af208c-d8d2-421e-9672-f7a4bc784317"), "Keyboard", new Guid("5da8ed8e-b31c-453a-a215-479048514319"), 3, 1463.14m },
                    { new Guid("b46666b0-a228-4ce7-9529-8bdcc58db6b0"), "Tablet", new Guid("01916843-8a88-4c4f-8d52-2c3758672a6d"), 1, 3677.23m },
                    { new Guid("b5318312-72bd-4bfe-8da6-36be65b706b2"), "Laptop", new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"), 1, 3572.80m },
                    { new Guid("b74ec874-74de-4d30-94ad-5e26bd5dfb6f"), "Tablet", new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"), 1, 2867.61m },
                    { new Guid("b9531b5c-9589-4b0f-b455-36a7af640b4e"), "Laptop", new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), 4, 2699.20m },
                    { new Guid("bd64a0bd-86cd-433b-a5d1-a1d886eed030"), "Tablet", new Guid("f1f5d7ec-381f-4341-bb6d-9f7001349123"), 2, 309.40m },
                    { new Guid("bd6cb0ed-552a-4c5e-953b-43c9236d1a0e"), "Laptop", new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), 2, 1517.84m },
                    { new Guid("be08fb09-00d1-442c-90af-02f565c4615e"), "Headset", new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), 3, 602.16m },
                    { new Guid("be957f79-366c-4e33-916c-9b588dda7bb3"), "Printer", new Guid("4c790b96-3e71-442c-8412-b08ac983771b"), 3, 659.85m },
                    { new Guid("c33a9509-f224-46d9-af99-4137c17fdc98"), "USB Drive", new Guid("595f3d82-1954-4398-83f5-38bb445abe6c"), 4, 2049.93m },
                    { new Guid("c33f16b5-fe1e-4e81-b613-5301e3df092e"), "USB Drive", new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"), 1, 388.91m },
                    { new Guid("c493bd64-f37d-4799-b963-3722d319fae6"), "Smartphone", new Guid("e115edaa-ea9f-4bff-babd-671ceeafe26c"), 4, 1833.05m },
                    { new Guid("c6ecc2be-cc34-4337-988b-6abfd0d410ca"), "Monitor", new Guid("7e4c0803-df8b-4a7d-a58a-f8a104595acb"), 1, 671.56m },
                    { new Guid("c7cbd6da-d455-449f-8738-35eb468ae87b"), "Tablet", new Guid("cd3dfae4-336e-43a1-af13-d215fc01c27c"), 2, 3440.00m },
                    { new Guid("ca3e0e5f-00d2-472b-b4a6-bb42295783db"), "USB Drive", new Guid("8c1b2538-9008-499f-9f16-95b69960eced"), 1, 3585.18m },
                    { new Guid("ca6ecd2b-c0c1-48e3-b35b-2a31f839daa1"), "Webcam", new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"), 3, 2971.17m },
                    { new Guid("cc2f3830-e258-413f-a259-2386152ba032"), "Laptop", new Guid("d8de140a-847e-4d42-a658-6754133b7f8d"), 4, 3162.46m },
                    { new Guid("cd52644d-de9e-486a-8bad-046ca6b81f0e"), "USB Drive", new Guid("02b34547-c1a4-42b4-ab37-1a799d3a5417"), 3, 2323.76m },
                    { new Guid("ce338974-f388-457c-a331-994e604937f7"), "Laptop", new Guid("595f3d82-1954-4398-83f5-38bb445abe6c"), 3, 2481.85m },
                    { new Guid("cf197087-f5d2-4fd3-a201-4521082ed8fa"), "Mouse", new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"), 2, 2447.75m },
                    { new Guid("d251ba80-51a2-460c-a045-2f4dcf0f4ee7"), "Laptop", new Guid("bdeb1778-ef64-4b65-b37b-704a0485f338"), 4, 2921.28m },
                    { new Guid("d2f5141d-14d2-43c9-8978-57affdce2e4e"), "Laptop", new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"), 3, 2619.36m },
                    { new Guid("d3a61201-1a3f-44cd-a318-194f0e14c1ae"), "Keyboard", new Guid("1adf054d-b6eb-40da-915b-38cba82c5b2c"), 2, 2176.64m },
                    { new Guid("d5b76a06-ff65-4c27-a5c3-d43efcc05b7b"), "Smartphone", new Guid("8d04a8e4-5c06-4d30-b011-b7fe9af5bc21"), 2, 575.75m },
                    { new Guid("d88bcabd-d4e3-4ebc-a983-ac030dc73028"), "Keyboard", new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), 4, 2460.07m },
                    { new Guid("da334d29-99fa-4745-abd7-e26bb380fbc4"), "Headset", new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"), 3, 4817.88m },
                    { new Guid("dadb35ab-5d0c-44b9-b079-6008334db905"), "Laptop", new Guid("8c1b2538-9008-499f-9f16-95b69960eced"), 1, 3927.57m },
                    { new Guid("dbc6eaa5-12fa-4776-9f92-634dff12b017"), "Laptop", new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"), 3, 1985.53m },
                    { new Guid("dd77df27-21fd-4843-8bbd-3838cf1b82ee"), "Laptop", new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"), 2, 1821.02m },
                    { new Guid("dfe39338-1ba5-4c0d-906a-7625646e7b16"), "Keyboard", new Guid("8d04a8e4-5c06-4d30-b011-b7fe9af5bc21"), 4, 4731.80m },
                    { new Guid("e0056829-58cf-4d20-ad3e-3f227dc365d3"), "Tablet", new Guid("5da8ed8e-b31c-453a-a215-479048514319"), 4, 4341.61m },
                    { new Guid("e106147a-9b3b-4f37-b883-6a9459c9c4ab"), "Printer", new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"), 2, 401.15m },
                    { new Guid("e48041eb-78a3-4413-8cf4-18fb3f5cb42e"), "USB Drive", new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), 3, 4845.13m },
                    { new Guid("e993a310-bf0c-42ba-a6b4-cf406d6a38b4"), "Laptop", new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"), 3, 4927.38m },
                    { new Guid("ea67b0ae-3015-4914-994e-49bd2558ca4b"), "Printer", new Guid("bf4fa2bc-10e5-41ee-abdf-e49c261e3179"), 2, 197.85m },
                    { new Guid("ea8725c7-ad71-4d42-9799-3ffc1ccc62b4"), "Printer", new Guid("02b34547-c1a4-42b4-ab37-1a799d3a5417"), 3, 1827.01m },
                    { new Guid("f0811d22-85e7-42ab-818d-00b2a2b2b0b9"), "Laptop", new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"), 3, 4582.78m },
                    { new Guid("f8081dff-3773-4aca-824d-2e33986964a9"), "Monitor", new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"), 1, 4236.43m },
                    { new Guid("fcdfa4dc-31e7-47f1-8633-bae9a956c69d"), "Headset", new Guid("6d618cf9-1e32-47aa-9cad-b99990d0580d"), 2, 4122.28m },
                    { new Guid("ffcb4be9-3cda-432b-b90d-63bc7e0be747"), "Mouse", new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"), 2, 3567.71m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("00e3ca5b-fe6a-42dd-a0be-7b94c4befbd4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0150adea-f338-46af-9844-565656fad216"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("048fd49d-e684-43e4-b0fe-87a497ad6a96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("052c9e30-b187-4547-bf2e-3dbb1bf69f1e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0f303d56-f4e0-4803-a53f-7c604f5b94cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("133bbb3c-1ee3-4aaf-ab56-25a28e29a558"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("19372f44-e4c3-4520-9404-8894d26ac1f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("19382867-74f7-4f07-b27d-48d4071d9eab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("197448d3-f8d3-4bdd-bfe4-486b51ed59f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1b217691-db97-4ae7-afd8-b85ee51428ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1bc24cc1-8196-4e9d-9edf-3a43ad7aecf2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c0c8348-c1a7-4847-9c7f-9e076699652d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c0fe3e5-d953-4911-b007-a12f5000344e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c174b13-3b65-4e8a-bfa0-2fa397410666"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1c2e2940-6e9b-4f1a-8002-f43d4a0bee0b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1d96522e-6108-4354-b071-fbd1447a1571"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1fd28e2e-9ef7-4a82-a745-27ba6765fd89"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("218e9a16-15bf-4ee0-8ccd-e9fc8bec2ad5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("22aa67c2-222e-427a-9414-7510d785536c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2472af87-b377-4738-9fe4-862538cb7ba3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("26936997-cc09-4c26-b01d-4aa331ec244a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("290edf76-e561-4639-a856-21df5ca8f54f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2a55e60d-a352-49c1-aaba-70a34fda379a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2b752a51-0631-4c6d-b0b5-2677e8a2910c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2f656480-ea6a-4f1b-9aa8-cc01e966787d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("32bb8153-9b4b-4017-80d9-6ad421399ec7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("347230b1-3145-44dd-9d60-cef27f0626b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("359b5b0f-c428-4f6c-a5e3-d39b889f8cb7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("35bf07a8-2127-45a6-acbf-25ed7b1e7dca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("36843148-963f-4a91-89a9-9b0ca17408e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("36e3f6ea-3b42-4f4c-a68d-4282f8d775b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3a7f437c-d7d1-4c2b-ae88-e336f7a7c388"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3bb40ad1-7ba4-4d0a-9a1d-bf26bb92946a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d5ccc4e-8931-4ff7-8180-9ad98bdf182a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3e1b0f6e-a89b-4214-bf61-ccc2fe7eb8b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("44697429-ed59-4998-8467-48d033d27570"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("47a67ae1-3518-4005-a2be-15ce15ec04bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4a7e65a6-4981-4a13-be60-4f6e65b5fdb3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4bd617e7-daa2-41ef-add2-e69c1d344d67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4df7df90-23e5-4685-a886-a91226de4cde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4ea6c1d5-95bc-410b-90de-68e5a4ed894e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5115a058-a8c4-4363-b2b8-eec499235b49"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("51537ee2-6991-40c0-ae2a-4e874b3f8bc3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5254739c-4563-40f6-b731-006bbc0b7082"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("532f70b7-7a25-47be-b25d-14a614920098"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("54a91c02-5839-4577-a696-d5fb63266414"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5711761c-e1e8-426e-87c4-d63ec9cd1f1a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5759d2d7-5974-4f92-a1c3-2a0a63485643"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("579439ca-7f74-449a-8bdb-fe005c8166a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("59318be8-41bd-44b0-a0ad-7c90316d3010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("59af9d9e-db8f-4e42-b567-760d4818b3b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("59b611e4-1867-4c8a-99bb-72dab95a947b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5b55e6fd-9d67-430a-ae9b-d12bff6ca8da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5b9a61d2-2a59-48c7-b040-55964dc1f96e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5dc73627-0008-41d1-9559-054f223cd02d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5f7668d4-37bf-4e8d-b634-4205c0e370d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("61afb093-96ec-440c-9eef-0d56c92f2af5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6335be91-b7f1-41a2-8460-5ed095f3da27"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("643cf904-fb02-48cb-abf7-e267a4e005e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("65565ab1-33e2-4101-b866-0b7fb34969b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("65bc4b92-6fca-480b-b124-910fd627e28a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("65d07be2-99a8-4d2e-a4ae-55612140cc4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("66ccde33-5f58-4d41-80af-9d538241f108"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6d0ece61-ff69-4b35-8a54-3fd5c10c53f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6d882db3-8941-47d1-9bc7-d9419e8b6d7c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6e13d87b-98db-4087-99dc-62f5b71f4660"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("712744b6-5433-44b0-89d6-03a88d6d6c45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("713cb899-37d4-4a40-bae5-36ab58d1aa8a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7248e3f8-4a32-47a9-8187-8ad54fc9426f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("737cb01f-f411-467e-887d-7bfe383104f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("746fee63-baa6-4c03-b2fe-939e120c4b5d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("84bfe5fb-7885-41f8-83c3-e6fcd3e54b6b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("872ac3ab-fa4e-4c2f-98df-c0853e8c8e1d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8786f3c4-2373-47ae-8997-505a19f748e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("87d75e54-6e8c-48a6-a72f-f163790cf3b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("88d52047-5278-4786-beb8-1f02dcd8d03b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8909e007-91fd-476f-89ed-b34d3a3b0d48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("896d5323-fce9-4ae4-be73-1396ed39558c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9595927d-a7c3-421b-b61f-7206784b77d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("96016659-cd3e-446e-858c-f92941ef957a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9625b626-9a4d-4a57-acf1-0ed6e6f6654d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("96546b7e-9bf7-4635-9e79-7b7c81f0df47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("96c78fa6-894d-4b3f-b428-a16212be350d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("989364c1-c9a8-4642-bd4e-a8a4f1e4479a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9b6fbbdd-a8d9-4ce2-9afb-9223396c61dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("9fbc1b43-fba7-439c-9de3-36b09310d7fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a0a99057-ba0a-4bd4-8740-a66f684b3873"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a17847cd-fcbf-4e35-9bed-a010bfefe594"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2901ccf-f030-44e1-8c76-aefe106037d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a607702b-32e6-41aa-8853-2e9319fbf6d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a62563ed-5fd6-4642-af9c-7753bab6f2bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ab30e394-7b7c-4ed2-9acc-d48a6bfc499f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("abf97b42-dbac-4ed2-a4d8-c6161252bfb9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("af9eca7e-e89e-4867-8190-85cb3c43ad48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b2172cad-03ff-4ab8-aa56-f73492220ca1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b2af208c-d8d2-421e-9672-f7a4bc784317"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b46666b0-a228-4ce7-9529-8bdcc58db6b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b5318312-72bd-4bfe-8da6-36be65b706b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b74ec874-74de-4d30-94ad-5e26bd5dfb6f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b9531b5c-9589-4b0f-b455-36a7af640b4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bd64a0bd-86cd-433b-a5d1-a1d886eed030"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bd6cb0ed-552a-4c5e-953b-43c9236d1a0e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("be08fb09-00d1-442c-90af-02f565c4615e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("be957f79-366c-4e33-916c-9b588dda7bb3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c33a9509-f224-46d9-af99-4137c17fdc98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c33f16b5-fe1e-4e81-b613-5301e3df092e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c493bd64-f37d-4799-b963-3722d319fae6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c6ecc2be-cc34-4337-988b-6abfd0d410ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c7cbd6da-d455-449f-8738-35eb468ae87b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ca3e0e5f-00d2-472b-b4a6-bb42295783db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ca6ecd2b-c0c1-48e3-b35b-2a31f839daa1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("cc2f3830-e258-413f-a259-2386152ba032"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("cd52644d-de9e-486a-8bad-046ca6b81f0e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ce338974-f388-457c-a331-994e604937f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("cf197087-f5d2-4fd3-a201-4521082ed8fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d251ba80-51a2-460c-a045-2f4dcf0f4ee7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d2f5141d-14d2-43c9-8978-57affdce2e4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d3a61201-1a3f-44cd-a318-194f0e14c1ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d5b76a06-ff65-4c27-a5c3-d43efcc05b7b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d88bcabd-d4e3-4ebc-a983-ac030dc73028"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("da334d29-99fa-4745-abd7-e26bb380fbc4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dadb35ab-5d0c-44b9-b079-6008334db905"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dbc6eaa5-12fa-4776-9f92-634dff12b017"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dd77df27-21fd-4843-8bbd-3838cf1b82ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dfe39338-1ba5-4c0d-906a-7625646e7b16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e0056829-58cf-4d20-ad3e-3f227dc365d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e106147a-9b3b-4f37-b883-6a9459c9c4ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e48041eb-78a3-4413-8cf4-18fb3f5cb42e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e993a310-bf0c-42ba-a6b4-cf406d6a38b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ea67b0ae-3015-4914-994e-49bd2558ca4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ea8725c7-ad71-4d42-9799-3ffc1ccc62b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f0811d22-85e7-42ab-818d-00b2a2b2b0b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f8081dff-3773-4aca-824d-2e33986964a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("fcdfa4dc-31e7-47f1-8633-bae9a956c69d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ffcb4be9-3cda-432b-b90d-63bc7e0be747"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("01916843-8a88-4c4f-8d52-2c3758672a6d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("02b34547-c1a4-42b4-ab37-1a799d3a5417"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("1adf054d-b6eb-40da-915b-38cba82c5b2c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("1cb82f7a-9a39-4ac5-962d-fb3be8b7f31e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("23447a11-9916-42dd-93e5-09fe025224e9"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("2a8aa5cc-e370-479f-88cf-199498c81410"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("2cbde594-d503-4b9e-a200-2bdf5c2416f6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("2fe7525d-e8d5-42ec-8728-2d4cc86c7071"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("364c23bf-7770-4b90-87cc-4dbe51a72f80"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3c90739f-80f9-4fee-aa41-7fcf1bc27551"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("40d266c7-38d2-40e9-9894-7ee7343ff16e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("41038d29-3764-4b34-aeb0-e3c87f950f24"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("4703c966-e97a-4ffe-97bb-922a9a9f0c2b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("4c790b96-3e71-442c-8412-b08ac983771b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("4e17370c-655c-4024-a0fb-5ad5d41af532"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("595f3d82-1954-4398-83f5-38bb445abe6c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("5ca258b5-6612-4f1d-84c6-05dea1c9dd44"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("5d6401b6-1d27-4f30-96d8-aee89ece5604"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("5da8ed8e-b31c-453a-a215-479048514319"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("65589077-31fa-41e3-a271-2c9af2052046"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("671212b2-8732-441e-81c9-7bfa1bbca4e6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("6d618cf9-1e32-47aa-9cad-b99990d0580d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("704ac39c-4331-491d-a8ec-01375655eeb5"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("722f677b-8dc1-4b8d-b527-d89388737d0a"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7c08ec62-77f2-4573-893a-898007c19b0b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e4c0803-df8b-4a7d-a58a-f8a104595acb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7f17be03-7c57-4a02-b6ff-5d51a997d25c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("859b6a9e-0d59-41e6-8007-c1977fc47e36"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("88d81a15-bc6c-495e-8f3f-218a5b85fac2"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("8c1b2538-9008-499f-9f16-95b69960eced"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("8d04a8e4-5c06-4d30-b011-b7fe9af5bc21"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("8ee3859f-a583-4fd8-8a20-46b5d84a47a0"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("90085c45-7a4e-49a6-8b9a-9ec70297b4ad"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("95f9b3a7-b3ee-44f7-9a85-8d45d8f3f10d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("9f7c830b-07ec-48b9-a5c1-fd2736bfcae2"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("a953969f-01bf-487f-898a-76a4ccb9df34"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("aa972f5b-a466-484b-978b-7dcd740d9d57"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("b57898a6-9445-450c-9bea-8ea7f33e6b97"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("bdeb1778-ef64-4b65-b37b-704a0485f338"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("bf4fa2bc-10e5-41ee-abdf-e49c261e3179"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("c72b0369-3ca7-4a37-8650-206b0aed7614"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("cb51b1e5-1146-4351-837f-d5a2100ab289"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("cd0275d6-3d73-4164-9928-bc6e48ca36c0"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("cd3dfae4-336e-43a1-af13-d215fc01c27c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("d8de140a-847e-4d42-a658-6754133b7f8d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("df0d2884-4250-4df6-bb3b-be0362560d7e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e115edaa-ea9f-4bff-babd-671ceeafe26c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e58fb697-c720-46ec-8405-ce077deb40af"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e99ee60e-9c59-4156-95dd-cfb63a9508bf"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f1f5d7ec-381f-4341-bb6d-9f7001349123"));

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
    }
}
