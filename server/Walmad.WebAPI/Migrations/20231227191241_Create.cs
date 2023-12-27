using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Walmad.Core.src.Entity;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:order_status", "pending,processing,shipping,shipped,cancelled")
                .Annotation("Npgsql:Enum:role", "admin,customer");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    role = table.Column<Role>(type: "role", nullable: false),
                    address_line1 = table.Column<string>(type: "text", nullable: false),
                    address_line2 = table.Column<string>(type: "text", nullable: true),
                    post_code = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    inventory = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.CheckConstraint("CHK_Product_Inventory_Positive", "inventory >= 0");
                    table.CheckConstraint("CHK_Product_Price_Positive", "price >= 0");
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_status = table.Column<OrderStatus>(type: "order_status", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_images_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    rating = table.Column<byte>(type: "smallint", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_products_product_id1",
                        column: x => x.product_id1,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    order_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_products", x => x.id);
                    table.CheckConstraint("CHK_OrderProduct_Quantity_Positive", "quantity >= 0");
                    table.ForeignKey(
                        name: "fk_order_products_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order_products_orders_order_id1",
                        column: x => x.order_id1,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "image", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(538), "https://picsum.photos/200", "Clothing", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(538) },
                    { new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(544), "https://picsum.photos/200", "Sports", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(544) },
                    { new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(542), "https://picsum.photos/200", "Books", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(543) },
                    { new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(540), "https://picsum.photos/200", "Home Decor", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(541) },
                    { new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(545), "https://picsum.photos/200", "Toys", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(546) },
                    { new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(172), "https://picsum.photos/200", "Electronic", new DateTime(2023, 12, 27, 19, 12, 41, 462, DateTimeKind.Utc).AddTicks(365) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_line1", "address_line2", "avatar", "city", "country", "created_at", "email", "name", "password", "post_code", "role", "salt", "updated_at" },
                values: new object[] { new Guid("441a9878-9116-4972-9f6a-9d47f54fbfa3"), "Olympiakatu 12", "C1", "https://picsum.photos/200", "Vaasa", "Finland", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(313), "superadmin@gmail.com", "SuperAdmin", "23-F6-F9-5B-1D-69-DE-33-42-35-99-C0-3B-61-8A-70-AF-AD-5A-D4-5C-71-B9-46-26-20-3C-B8-C3-B4-3E-19", 65100, Role.Admin, new byte[] { 209, 73, 127, 54, 115, 231, 214, 116, 102, 77, 76, 210, 44, 189, 23, 182, 125, 122, 238, 77, 35, 252, 135, 230, 44, 130, 161, 200, 147, 204, 30, 71, 32, 141, 0, 132, 182, 136, 208, 205, 168, 46, 48, 160, 155, 206, 176, 108, 126, 184, 127, 82, 178, 31, 195, 9, 215, 157, 100, 231, 88, 34, 179, 95 }, new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(314) });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "created_at", "description", "inventory", "price", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("02fb5524-c0f8-4a23-b47a-146ed907c363"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1128), "Description for Toys Product 4", 100, 40m, "Toys Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1128) },
                    { new Guid("049a7dcc-6834-45b9-8bd4-6e9f185cf91f"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(848), "Description for Clothing Product 20", 100, 200m, "Clothing Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(848) },
                    { new Guid("05d7c4ac-9138-49d0-b81c-d1b6acdfde9e"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(922), "Description for Home Decor Product 19", 100, 190m, "Home Decor Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(923) },
                    { new Guid("06f689fa-b694-49a3-93b5-ad97bd646a17"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1191), "Description for Toys Product 14", 100, 140m, "Toys Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1191) },
                    { new Guid("06f783a1-9b79-4869-ab9c-c7649b0411be"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(845), "Description for Clothing Product 19", 100, 190m, "Clothing Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(845) },
                    { new Guid("0cd5c20d-d456-4848-b3ab-c7ecb7bd51d0"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(908), "Description for Home Decor Product 13", 100, 130m, "Home Decor Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(908) },
                    { new Guid("0cede8d8-6be1-4a70-b30b-5178f2c80103"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(940), "Description for Books Product 5", 100, 50m, "Books Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(940) },
                    { new Guid("0efe3115-4fd2-4e15-8030-dc9501240b8e"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(731), "Description for Electronic Product 9", 100, 90m, "Electronic Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(732) },
                    { new Guid("1300f9b1-df3a-451d-9e6a-d9c9f90f418e"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(957), "Description for Books Product 11", 100, 110m, "Books Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(957) },
                    { new Guid("17047b5c-10b9-49d5-99fc-da24429a2308"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(893), "Description for Home Decor Product 8", 100, 80m, "Home Decor Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(893) },
                    { new Guid("1787615b-381a-4e22-83d3-3278b341ed18"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(945), "Description for Books Product 7", 100, 70m, "Books Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(945) },
                    { new Guid("18e8b056-970e-447d-ad53-57561cc04963"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1178), "Description for Toys Product 9", 100, 90m, "Toys Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1178) },
                    { new Guid("19ac8fbf-60a4-4b73-a314-30186edfa917"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(890), "Description for Home Decor Product 7", 100, 70m, "Home Decor Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(890) },
                    { new Guid("1b6898ac-c604-4bbb-8185-0bf5d8e29a49"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1036), "Description for Sports Product 12", 100, 120m, "Sports Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1036) },
                    { new Guid("1b71a4be-17ce-48f5-a6ba-013eb80cc6d8"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1205), "Description for Toys Product 19", 100, 190m, "Toys Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1205) },
                    { new Guid("1bf1c31f-7731-48b4-b122-b1bf9fa98d62"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(853), "Description for Home Decor Product 1", 100, 10m, "Home Decor Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(853) },
                    { new Guid("1c3e3cd8-4e30-47a5-aaf4-9ad4aca19d4c"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(762), "Description for Electronic Product 19", 100, 190m, "Electronic Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(762) },
                    { new Guid("25f74b2a-d038-4cb4-b9ac-cd479741dcda"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(800), "Description for Clothing Product 3", 100, 30m, "Clothing Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(800) },
                    { new Guid("27c54a9e-4e3f-483d-a9dd-e8b7a6daaac5"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(856), "Description for Home Decor Product 2", 100, 20m, "Home Decor Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(856) },
                    { new Guid("2865bce7-eef1-458b-96ed-5f0c56e74c37"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(933), "Description for Books Product 2", 100, 20m, "Books Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(934) },
                    { new Guid("289ada00-049e-4920-8718-f0e1174f1626"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1000), "Description for Books Product 20", 100, 200m, "Books Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1001) },
                    { new Guid("2c8e202e-ae2d-4282-be9d-844ecf4563de"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(865), "Description for Home Decor Product 5", 100, 50m, "Home Decor Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(866) },
                    { new Guid("2e81031c-9ac1-41d1-a445-b5b0912e1b5c"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(901), "Description for Home Decor Product 11", 100, 110m, "Home Decor Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(902) },
                    { new Guid("30244d15-fe50-44e8-834b-5cabd471acb3"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(895), "Description for Home Decor Product 9", 100, 90m, "Home Decor Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(896) },
                    { new Guid("344f7888-558c-4677-aa28-67cf33de4874"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1032), "Description for Sports Product 11", 100, 110m, "Sports Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1032) },
                    { new Guid("3648af14-d844-4aeb-84c3-5808d2f412d5"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(951), "Description for Books Product 9", 100, 90m, "Books Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(951) },
                    { new Guid("37747fd6-64b1-4907-8d0a-6cdfc9543902"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(832), "Description for Clothing Product 15", 100, 150m, "Clothing Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(833) },
                    { new Guid("382d0f7a-7bf3-4f33-862b-8d4dfa3f41c6"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(986), "Description for Books Product 15", 100, 150m, "Books Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(987) },
                    { new Guid("3e847d37-c6d0-4f78-a0b0-d529dbb32143"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(721), "Description for Electronic Product 5", 100, 50m, "Electronic Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(721) },
                    { new Guid("426e1409-a155-4636-bf34-e6429e7756e0"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1193), "Description for Toys Product 15", 100, 150m, "Toys Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1194) },
                    { new Guid("42b545f1-11cd-46ca-aaf0-75bcdfa96f0f"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(830), "Description for Clothing Product 14", 100, 140m, "Clothing Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(831) },
                    { new Guid("456a22a8-6d05-4098-b7e8-bca39c45c0be"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(859), "Description for Home Decor Product 3", 100, 30m, "Home Decor Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(859) },
                    { new Guid("45ad1945-b6cf-456a-9e45-d3f7638beb77"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1021), "Description for Sports Product 7", 100, 70m, "Sports Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1021) },
                    { new Guid("473e5c54-2b6c-4e79-ba41-37da16e3a444"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(738), "Description for Electronic Product 11", 100, 110m, "Electronic Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(739) },
                    { new Guid("47fa1c1f-8bd2-4349-a049-59bdd80fef91"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(839), "Description for Clothing Product 17", 100, 170m, "Clothing Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(839) },
                    { new Guid("48081f53-02bc-4916-bd2a-f8c5c20b213a"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(842), "Description for Clothing Product 18", 100, 180m, "Clothing Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(843) },
                    { new Guid("486d1ba4-51ef-4df9-bd4e-79a7d9361ee9"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(990), "Description for Books Product 16", 100, 160m, "Books Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(991) },
                    { new Guid("48c38b3e-8e10-488e-8db0-57281d27f3b0"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(797), "Description for Clothing Product 2", 100, 20m, "Clothing Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(797) },
                    { new Guid("496f9603-f205-4de0-98fd-64fcc439652a"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1184), "Description for Toys Product 11", 100, 110m, "Toys Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1184) },
                    { new Guid("49d78af6-a9a1-4fa9-9574-5f78e9df96a6"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1016), "Description for Sports Product 5", 100, 50m, "Sports Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1016) },
                    { new Guid("4a5de11c-77ca-4fd8-a0db-0d9534d87eb0"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(931), "Description for Books Product 1", 100, 10m, "Books Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(931) },
                    { new Guid("4b941c6a-f1e7-45df-b062-fdcd856b6620"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(920), "Description for Home Decor Product 18", 100, 180m, "Home Decor Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(920) },
                    { new Guid("4df0f1a4-de4f-4f0a-bd3c-3a827a193837"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(836), "Description for Clothing Product 16", 100, 160m, "Clothing Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(837) },
                    { new Guid("4e7e1715-9fc0-4c44-ae4b-ed2f051c184d"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(727), "Description for Electronic Product 7", 100, 70m, "Electronic Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(727) },
                    { new Guid("4ed14b21-1fc4-477a-8856-37e81d38fc92"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1199), "Description for Toys Product 17", 100, 170m, "Toys Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1200) },
                    { new Guid("4ee431c6-176e-4611-9d21-e8a1cc3a4910"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(995), "Description for Books Product 18", 100, 180m, "Books Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(996) },
                    { new Guid("4f22d8b2-e636-44d7-95da-35aa114e0d28"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(822), "Description for Clothing Product 11", 100, 110m, "Clothing Product 11", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(823) },
                    { new Guid("517a186b-ff0e-48b9-8d0c-2f3b695f511a"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(772), "Description for Clothing Product 1", 100, 10m, "Clothing Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(773) },
                    { new Guid("558103cf-8d93-434f-b43b-c932e31cee6f"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1123), "Description for Toys Product 2", 100, 20m, "Toys Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1123) },
                    { new Guid("56f97a92-8f5d-4771-8b06-54257b5d3df5"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1004), "Description for Sports Product 1", 100, 10m, "Sports Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1004) },
                    { new Guid("57030b60-ddad-4d2d-a054-b6d6be03403e"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(993), "Description for Books Product 17", 100, 170m, "Books Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(993) },
                    { new Guid("579a0f7a-d45d-4a51-aae6-5f1d4f9fbe7c"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(918), "Description for Home Decor Product 17", 100, 170m, "Home Decor Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(918) },
                    { new Guid("57e00b8f-ccc5-46c9-bba2-86012c08baca"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1014), "Description for Sports Product 4", 100, 40m, "Sports Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1014) },
                    { new Guid("5c7a587b-e11d-46f0-8605-62a49b85a733"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(936), "Description for Books Product 3", 100, 30m, "Books Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(936) },
                    { new Guid("5f412f97-e30c-4f34-8308-5322398c089f"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(954), "Description for Books Product 10", 100, 100m, "Books Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(955) },
                    { new Guid("62057917-2b83-406f-b70f-b2ca2ea5ea6c"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(802), "Description for Clothing Product 4", 100, 40m, "Clothing Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(803) },
                    { new Guid("6635f728-c28e-403a-924b-ec5a6014f403"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1120), "Description for Toys Product 1", 100, 10m, "Toys Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1120) },
                    { new Guid("66a81c5e-fdc2-4f99-8347-fe4c15ea4f4b"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1140), "Description for Toys Product 8", 100, 80m, "Toys Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1140) },
                    { new Guid("7061541d-8a6b-41bc-8800-777cbce7f615"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1050), "Description for Sports Product 18", 100, 180m, "Sports Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1051) },
                    { new Guid("7385bfb1-7d2f-4b5d-b45b-ea82d666ff90"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(748), "Description for Electronic Product 14", 100, 140m, "Electronic Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(748) },
                    { new Guid("74483312-31bb-4ab5-897e-fe4b799b7852"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(756), "Description for Electronic Product 17", 100, 170m, "Electronic Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(757) },
                    { new Guid("75da1b38-3714-43ec-a7ee-ca68b7b4d152"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(705), "Description for Electronic Product 1", 100, 10m, "Electronic Product 1", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(705) },
                    { new Guid("7762c323-410d-4884-b825-b0816f9c40f4"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(926), "Description for Home Decor Product 20", 100, 200m, "Home Decor Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(926) },
                    { new Guid("799c1ce7-9b51-4ab5-b794-0e7b833755ae"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1048), "Description for Sports Product 17", 100, 170m, "Sports Product 17", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1048) },
                    { new Guid("7aa9fdcd-f7fc-410a-a68e-294aa1e58559"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(978), "Description for Books Product 12", 100, 120m, "Books Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(979) },
                    { new Guid("7b0fec2f-0c80-4775-9849-2b3f9aa1e82e"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1029), "Description for Sports Product 10", 100, 100m, "Sports Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1029) },
                    { new Guid("7c2e7200-2d0c-43e4-980e-67a8d3d8490c"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(984), "Description for Books Product 14", 100, 140m, "Books Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(984) },
                    { new Guid("7d470d20-bdde-494c-934c-0da478b23b2e"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(998), "Description for Books Product 19", 100, 190m, "Books Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(998) },
                    { new Guid("863d34d2-92db-464f-ba63-16fd39898e99"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1041), "Description for Sports Product 14", 100, 140m, "Sports Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1041) },
                    { new Guid("86f00fcb-ad3b-4d30-b51b-ecebaef0af87"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1135), "Description for Toys Product 7", 100, 70m, "Toys Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1136) },
                    { new Guid("8760ebc6-a06f-4b8b-9c1e-d8551c1a99c5"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(751), "Description for Electronic Product 15", 100, 150m, "Electronic Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(751) },
                    { new Guid("89f32f86-1b59-43ba-b333-6b426729bd4e"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(910), "Description for Home Decor Product 14", 100, 140m, "Home Decor Product 14", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(910) },
                    { new Guid("8ca139a2-8cda-48df-9dc6-5851ad888278"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1024), "Description for Sports Product 8", 100, 80m, "Sports Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1024) },
                    { new Guid("9500bc9d-a08b-4f01-9f1a-d5f13be4b479"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1133), "Description for Toys Product 6", 100, 60m, "Toys Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1133) },
                    { new Guid("979482ac-ea45-4a3c-bd93-f4ae4514232c"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1189), "Description for Toys Product 13", 100, 130m, "Toys Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1189) },
                    { new Guid("98c51a86-9094-4d8c-952e-69cf3db936f3"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(729), "Description for Electronic Product 8", 100, 80m, "Electronic Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(729) },
                    { new Guid("9b01360e-bfa6-4d6a-a049-ebcf3e58fe72"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1043), "Description for Sports Product 15", 100, 150m, "Sports Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1043) },
                    { new Guid("9c3e0236-cf96-4d93-8451-ed5c2ee951be"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1186), "Description for Toys Product 12", 100, 120m, "Toys Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1186) },
                    { new Guid("9cfff71d-bc07-4888-8c78-02360fd0e662"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1010), "Description for Sports Product 3", 100, 30m, "Sports Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1010) },
                    { new Guid("a0b72aa4-a134-4d8e-b67e-e63a99a0c981"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(808), "Description for Clothing Product 6", 100, 60m, "Clothing Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(808) },
                    { new Guid("a1ccf2c8-f334-4dd7-bb57-e0cde8ab7aff"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(753), "Description for Electronic Product 16", 100, 160m, "Electronic Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(754) },
                    { new Guid("a329105a-025b-4c55-9774-86dbcb4771b7"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(913), "Description for Home Decor Product 15", 100, 150m, "Home Decor Product 15", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(913) },
                    { new Guid("a7172a36-bb4a-4078-8e7d-d68e55966204"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1053), "Description for Sports Product 19", 100, 190m, "Sports Product 19", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1053) },
                    { new Guid("a8f21be1-3a96-453b-8ced-37f94b8ca485"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1045), "Description for Sports Product 16", 100, 160m, "Sports Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1046) },
                    { new Guid("a9916b0c-66c8-420f-8952-a07417b89e23"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(719), "Description for Electronic Product 4", 100, 40m, "Electronic Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(719) },
                    { new Guid("acd3b3c2-bb47-41df-a3f9-09370a4ff380"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(759), "Description for Electronic Product 18", 100, 180m, "Electronic Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(759) },
                    { new Guid("af214b43-5b80-40be-81be-e00344ae200f"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1038), "Description for Sports Product 13", 100, 130m, "Sports Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1039) },
                    { new Guid("b3008547-1eb1-41ad-99c4-0baaf9c4d831"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(828), "Description for Clothing Product 13", 100, 130m, "Clothing Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(828) },
                    { new Guid("b386da5c-d716-4197-835c-129719a0e588"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1105), "Description for Sports Product 20", 100, 200m, "Sports Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1105) },
                    { new Guid("b38a64c5-8ed3-434b-be8d-85185c3f96c1"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(905), "Description for Home Decor Product 12", 100, 120m, "Home Decor Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(905) },
                    { new Guid("b47f33f5-7293-4062-8529-a909f1758aa5"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1207), "Description for Toys Product 20", 100, 200m, "Toys Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1207) },
                    { new Guid("b6b91c9b-c47d-40bc-83c0-04997a1b8073"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(712), "Description for Electronic Product 3", 100, 30m, "Electronic Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(713) },
                    { new Guid("b73f28aa-a8ea-46eb-a245-e04cfbda6adf"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(943), "Description for Books Product 6", 100, 60m, "Books Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(943) },
                    { new Guid("b7dbec7d-5120-469c-b4af-2ddd4ef24ccb"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(981), "Description for Books Product 13", 100, 130m, "Books Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(981) },
                    { new Guid("b81d54c3-8cf7-4787-9536-fefef4fa2eb2"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(805), "Description for Clothing Product 5", 100, 50m, "Clothing Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(805) },
                    { new Guid("c17f9e11-700e-4650-a7d6-007f109429f8"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(766), "Description for Electronic Product 20", 100, 200m, "Electronic Product 20", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(766) },
                    { new Guid("c2d04e27-a95b-4df8-bd4b-1ec3304a0ebe"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(938), "Description for Books Product 4", 100, 40m, "Books Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(938) },
                    { new Guid("c3883200-91a4-40a8-b59c-1da55126d9f6"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(735), "Description for Electronic Product 10", 100, 100m, "Electronic Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(736) },
                    { new Guid("c758a929-a14d-4b74-a71e-8e6b912524e9"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(898), "Description for Home Decor Product 10", 100, 100m, "Home Decor Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(899) },
                    { new Guid("c8686634-b0d8-44b8-a5e9-8bab4cb0f3fb"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1130), "Description for Toys Product 5", 100, 50m, "Toys Product 5", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1131) },
                    { new Guid("c8af0629-5cad-41a2-b863-bbe1bf68f00e"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1019), "Description for Sports Product 6", 100, 60m, "Sports Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1019) },
                    { new Guid("c8eb4236-064d-411e-b865-97f648cfe456"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(709), "Description for Electronic Product 2", 100, 20m, "Electronic Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(710) },
                    { new Guid("ca4d530a-347c-4b9e-a01f-7994121c730f"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(810), "Description for Clothing Product 7", 100, 70m, "Clothing Product 7", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(810) },
                    { new Guid("ce4f3d64-d57b-4b07-be78-90229323650d"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(820), "Description for Clothing Product 10", 100, 100m, "Clothing Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(820) },
                    { new Guid("d21606ac-752e-49da-8a91-1f45b2fc5998"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1197), "Description for Toys Product 16", 100, 160m, "Toys Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1197) },
                    { new Guid("d4717102-74a9-42e7-882f-fd8006a672de"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1125), "Description for Toys Product 3", 100, 30m, "Toys Product 3", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1126) },
                    { new Guid("d791c111-c226-415a-ae40-2a7a31401a04"), new Guid("76fd43e2-892e-43f0-8615-79529d95b895"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(949), "Description for Books Product 8", 100, 80m, "Books Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(949) },
                    { new Guid("db146a1e-52d7-4a81-b3e9-f85fd6b6b720"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(915), "Description for Home Decor Product 16", 100, 160m, "Home Decor Product 16", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(915) },
                    { new Guid("dee3a9ed-e8d5-4f63-9280-c113cf019b6a"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1026), "Description for Sports Product 9", 100, 90m, "Sports Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1026) },
                    { new Guid("e1dcf5d2-fcc9-492c-8684-733e8bc4c7d2"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(862), "Description for Home Decor Product 4", 100, 40m, "Home Decor Product 4", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(863) },
                    { new Guid("e65bc17a-3aa2-4972-8768-da723cb99334"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(724), "Description for Electronic Product 6", 100, 60m, "Electronic Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(724) },
                    { new Guid("e88b7b02-3459-4d6c-b8c0-e618fafa6da1"), new Guid("07c6df9b-ec47-4dc9-903f-a906c3717ca4"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1007), "Description for Sports Product 2", 100, 20m, "Sports Product 2", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1007) },
                    { new Guid("ea15ce7a-b83f-4a17-b0a6-5b04246da0e6"), new Guid("ab91dd34-5c1a-4535-b71d-0e182f98fdc7"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(868), "Description for Home Decor Product 6", 100, 60m, "Home Decor Product 6", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(869) },
                    { new Guid("eb16b2b8-c690-4711-8056-30c12198e4a7"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(815), "Description for Clothing Product 8", 100, 80m, "Clothing Product 8", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(815) },
                    { new Guid("ed6ec109-b4d6-4a30-af0c-02310bb3ad41"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1202), "Description for Toys Product 18", 100, 180m, "Toys Product 18", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1203) },
                    { new Guid("efd73d50-e43a-4189-9175-a859d2092ac4"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(817), "Description for Clothing Product 9", 100, 90m, "Clothing Product 9", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(817) },
                    { new Guid("f43581fb-da82-4b85-9744-5279ae479bc3"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(745), "Description for Electronic Product 13", 100, 130m, "Electronic Product 13", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(746) },
                    { new Guid("f44b6789-cc4f-48e6-9019-75ff5d917200"), new Guid("edebd01a-2a88-4c3d-9f6d-55489443ae32"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(743), "Description for Electronic Product 12", 100, 120m, "Electronic Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(743) },
                    { new Guid("fa45fa8b-95a9-4647-adb4-dfe64fb52371"), new Guid("0695201d-59f8-42a4-87c8-95a356362032"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(825), "Description for Clothing Product 12", 100, 120m, "Clothing Product 12", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(825) },
                    { new Guid("ff0c07e6-c6b1-4de6-99c7-11318773f700"), new Guid("bb61054e-386e-4296-bb95-b75ede5ea136"), new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1181), "Description for Toys Product 10", 100, 100m, "Toys Product 10", new DateTime(2023, 12, 27, 19, 12, 41, 684, DateTimeKind.Utc).AddTicks(1181) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_name",
                table: "categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_products_order_id",
                table: "order_products",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_products_order_id1",
                table: "order_products",
                column: "order_id1");

            migrationBuilder.CreateIndex(
                name: "ix_order_products_product_id",
                table: "order_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_images_product_id",
                table: "product_images",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_product_id",
                table: "reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_product_id1",
                table: "reviews",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id1",
                table: "reviews",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_products");

            migrationBuilder.DropTable(
                name: "product_images");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
