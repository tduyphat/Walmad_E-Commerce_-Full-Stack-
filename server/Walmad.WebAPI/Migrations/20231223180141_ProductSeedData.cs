using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Walmad.Core.src.Entity;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("4604008c-d068-4da0-b1e6-c27be53967d8"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("5846635c-a18b-4dfa-89c7-c75ca344166e"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("8db6d526-c334-4344-b621-f0361ba73fa6"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("b70991de-ee61-4958-80ac-1495bc3ad818"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("e21c44ba-9872-414b-aa3a-ab95ae33c1c3"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("e37711a1-d081-4d6e-8c29-d359ea592686"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("eb9b9aaa-6360-4dea-ad37-04aaf0805e94"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "image", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("3c629d75-5183-452a-8dba-515067f4a837"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6439), "https://picsum.photos/200", "Books", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6439) },
                    { new Guid("4728694e-385e-4463-8c31-44c60dc38c24"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6441), "https://picsum.photos/200", "Sports", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6441) },
                    { new Guid("69bfa267-b8c6-4d13-9fa2-3dd841682958"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6442), "https://picsum.photos/200", "Toys", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6443) },
                    { new Guid("dbcc2bd6-945a-4ee3-83f9-7a511ac7e8ec"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6437), "https://picsum.photos/200", "Home Decor", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6437) },
                    { new Guid("e8f3ab8e-525f-4596-8226-d348ef4ab56a"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6434), "https://picsum.photos/200", "Clothing", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6435) },
                    { new Guid("ebab49d3-3549-417d-bbb1-bf9bb067fccf"), new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6071), "https://picsum.photos/200", "Electronic", new DateTime(2023, 12, 23, 18, 1, 41, 194, DateTimeKind.Utc).AddTicks(6262) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_line1", "address_line2", "avatar", "city", "country", "created_at", "email", "name", "password", "post_code", "role", "salt", "updated_at" },
                values: new object[] { new Guid("6174f173-d035-4ed2-81e6-84fdcfd588f4"), "Olympiakatu 12", "C1", "https://picsum.photos/200", "Vaasa", "Finland", new DateTime(2023, 12, 23, 18, 1, 41, 426, DateTimeKind.Utc).AddTicks(3025), "superadmin@gmail.com", "SuperAdmin", "FA-E6-9B-F2-E0-7C-96-96-EC-01-13-7A-A4-19-32-C9-63-B8-49-34-6A-68-33-D7-3C-4D-22-DF-75-DC-C2-ED", 65100, Role.Admin, new byte[] { 166, 62, 16, 174, 235, 140, 75, 93, 118, 35, 210, 130, 27, 221, 153, 13, 196, 83, 117, 11, 46, 251, 65, 123, 61, 157, 63, 186, 76, 200, 217, 12, 1, 182, 246, 170, 74, 7, 156, 95, 87, 24, 119, 170, 13, 191, 4, 9, 243, 228, 130, 115, 143, 51, 60, 151, 237, 20, 0, 209, 22, 187, 59, 23 }, new DateTime(2023, 12, 23, 18, 1, 41, 426, DateTimeKind.Utc).AddTicks(3029) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("3c629d75-5183-452a-8dba-515067f4a837"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("4728694e-385e-4463-8c31-44c60dc38c24"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("69bfa267-b8c6-4d13-9fa2-3dd841682958"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("dbcc2bd6-945a-4ee3-83f9-7a511ac7e8ec"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("e8f3ab8e-525f-4596-8226-d348ef4ab56a"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("ebab49d3-3549-417d-bbb1-bf9bb067fccf"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("6174f173-d035-4ed2-81e6-84fdcfd588f4"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "image", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("4604008c-d068-4da0-b1e6-c27be53967d8"), new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(153), "https://picsum.photos/200", "Toys", new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(153) },
                    { new Guid("5846635c-a18b-4dfa-89c7-c75ca344166e"), new DateTime(2023, 12, 23, 17, 56, 15, 168, DateTimeKind.Utc).AddTicks(9771), "https://picsum.photos/200", "Electronic", new DateTime(2023, 12, 23, 17, 56, 15, 168, DateTimeKind.Utc).AddTicks(9962) },
                    { new Guid("8db6d526-c334-4344-b621-f0361ba73fa6"), new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(144), "https://picsum.photos/200", "Clothing", new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(145) },
                    { new Guid("b70991de-ee61-4958-80ac-1495bc3ad818"), new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(147), "https://picsum.photos/200", "Home Decor", new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(147) },
                    { new Guid("e21c44ba-9872-414b-aa3a-ab95ae33c1c3"), new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(151), "https://picsum.photos/200", "Sports", new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(151) },
                    { new Guid("e37711a1-d081-4d6e-8c29-d359ea592686"), new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(149), "https://picsum.photos/200", "Books", new DateTime(2023, 12, 23, 17, 56, 15, 169, DateTimeKind.Utc).AddTicks(149) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_line1", "address_line2", "avatar", "city", "country", "created_at", "email", "name", "password", "post_code", "role", "salt", "updated_at" },
                values: new object[] { new Guid("eb9b9aaa-6360-4dea-ad37-04aaf0805e94"), "Olympiakatu 12", "C1", "https://picsum.photos/200", "Vaasa", "Finland", new DateTime(2023, 12, 23, 17, 56, 15, 373, DateTimeKind.Utc).AddTicks(7455), "superadmin@gmail.com", "SuperAdmin", "30-83-DA-AD-F3-8A-A7-6C-7A-18-E8-54-4F-21-2D-F4-ED-CF-40-3B-77-CA-AA-F1-A7-D5-A0-28-12-FC-C9-AE", 65100, Role.Admin, new byte[] { 154, 143, 207, 81, 100, 167, 203, 93, 219, 193, 99, 228, 110, 145, 18, 132, 252, 238, 69, 219, 19, 141, 17, 23, 77, 35, 118, 173, 93, 132, 249, 155, 141, 158, 222, 230, 13, 188, 214, 138, 21, 15, 34, 132, 166, 159, 21, 59, 122, 203, 102, 56, 183, 124, 139, 94, 151, 164, 183, 93, 30, 112, 153, 250 }, new DateTime(2023, 12, 23, 17, 56, 15, 373, DateTimeKind.Utc).AddTicks(7456) });
        }
    }
}
