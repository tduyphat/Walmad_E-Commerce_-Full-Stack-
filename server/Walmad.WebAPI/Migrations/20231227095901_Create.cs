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
                    { new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7563), "https://picsum.photos/200", "Sports", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7563) },
                    { new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(6966), "https://picsum.photos/200", "Electronic", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7232) },
                    { new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7565), "https://picsum.photos/200", "Toys", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7565) },
                    { new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7557), "https://picsum.photos/200", "Clothing", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7557) },
                    { new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7561), "https://picsum.photos/200", "Books", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7562) },
                    { new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7559), "https://picsum.photos/200", "Home Decor", new DateTime(2023, 12, 27, 9, 59, 1, 156, DateTimeKind.Utc).AddTicks(7560) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_line1", "address_line2", "avatar", "city", "country", "created_at", "email", "name", "password", "post_code", "role", "salt", "updated_at" },
                values: new object[] { new Guid("df67012c-d6cd-437c-96a8-d8e83496b4c8"), "Olympiakatu 12", "C1", "https://picsum.photos/200", "Vaasa", "Finland", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(4903), "superadmin@gmail.com", "SuperAdmin", "49-49-2B-88-EB-59-75-BD-61-B6-78-41-1A-42-6B-85-A8-01-1F-F2-1B-1F-2D-17-8F-0B-98-6E-49-BD-AE-D2", 65100, Role.Admin, new byte[] { 115, 137, 20, 107, 236, 7, 176, 142, 91, 192, 128, 77, 54, 13, 61, 156, 89, 129, 98, 53, 107, 232, 127, 44, 213, 50, 152, 243, 71, 154, 116, 145, 79, 131, 117, 152, 193, 32, 64, 160, 65, 176, 169, 170, 33, 231, 233, 38, 78, 232, 209, 226, 64, 228, 90, 186, 128, 55, 219, 100, 29, 161, 155, 25 }, new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(4905) });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "created_at", "description", "inventory", "price", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("00eb8fcf-8d27-4805-81b5-46a270d07b6e"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5592), "Description for Books Product 10", 100, 100m, "Books Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5592) },
                    { new Guid("020acacd-035e-48ec-952a-2fe14d12f036"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5389), "Description for Electronic Product 17", 100, 170m, "Electronic Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5390) },
                    { new Guid("02f39550-1126-48ff-b22f-ecb936cd61e7"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5575), "Description for Books Product 4", 100, 40m, "Books Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5576) },
                    { new Guid("03c15b65-c864-4ad7-a810-8aa7d0dce583"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5450), "Description for Clothing Product 8", 100, 80m, "Clothing Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5450) },
                    { new Guid("05d6d4ad-07a0-4d38-bd06-fc40389959f3"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5363), "Description for Electronic Product 8", 100, 80m, "Electronic Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5364) },
                    { new Guid("0858e8c0-4988-4890-8862-99a9cee59c99"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5758), "Description for Toys Product 15", 100, 150m, "Toys Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5759) },
                    { new Guid("09782099-8a46-428f-ad86-ee1f35a2360c"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5361), "Description for Electronic Product 7", 100, 70m, "Electronic Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5361) },
                    { new Guid("09e2cc92-0787-4f1d-bed6-6369e1765da4"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5474), "Description for Clothing Product 17", 100, 170m, "Clothing Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5474) },
                    { new Guid("0d284227-d7d7-4add-9047-9ccec03fc747"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5639), "Description for Books Product 20", 100, 200m, "Books Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5639) },
                    { new Guid("0ddac43f-a8de-48c3-81cf-de9b8d0153c5"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5352), "Description for Electronic Product 4", 100, 40m, "Electronic Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5352) },
                    { new Guid("0df1c865-27ae-4a3e-9f8a-001408de49a3"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5452), "Description for Clothing Product 9", 100, 90m, "Clothing Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5453) },
                    { new Guid("11901810-2529-4e9f-847b-a6ff2735c6d7"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5631), "Description for Books Product 17", 100, 170m, "Books Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5632) },
                    { new Guid("16d9efa6-6ca1-490d-8057-4bf6b688ea69"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5542), "Description for Home Decor Product 12", 100, 120m, "Home Decor Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5543) },
                    { new Guid("259368a2-99a8-47e9-b814-3435604862aa"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5734), "Description for Toys Product 6", 100, 60m, "Toys Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5734) },
                    { new Guid("276430ac-ff17-4f9c-b5c6-23b0375f381a"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5366), "Description for Electronic Product 9", 100, 90m, "Electronic Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5366) },
                    { new Guid("27e6667a-6c9c-4e20-81ba-42acd8941b9d"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5392), "Description for Electronic Product 18", 100, 180m, "Electronic Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5392) },
                    { new Guid("2d69414a-84e5-479f-b5ed-f51545a457bb"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5410), "Description for Clothing Product 2", 100, 20m, "Clothing Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5410) },
                    { new Guid("2ee17632-a2ad-45b5-94c4-79b5e0824131"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5512), "Description for Home Decor Product 10", 100, 100m, "Home Decor Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5513) },
                    { new Guid("30f1083a-4a1e-474d-bd5a-e92a7e2cc45d"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5769), "Description for Toys Product 19", 100, 190m, "Toys Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("31f4580a-e384-4bfd-85d6-9f83f29e4859"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5690), "Description for Sports Product 18", 100, 180m, "Sports Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5690) },
                    { new Guid("34a2c5c7-7b14-4010-85ed-3888482768a1"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5466), "Description for Clothing Product 14", 100, 140m, "Clothing Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5466) },
                    { new Guid("36f19db3-0835-453c-b6b1-74c9d1d91388"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5658), "Description for Sports Product 6", 100, 60m, "Sports Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5658) },
                    { new Guid("3836df81-07ce-4782-8ca9-7332a09837ac"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5369), "Description for Electronic Product 10", 100, 100m, "Electronic Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5370) },
                    { new Guid("39c061bc-27a0-4dab-bd68-b04d410afd8e"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5571), "Description for Books Product 2", 100, 20m, "Books Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5571) },
                    { new Guid("3ae82e13-007b-4614-a92c-078f71c42b0a"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5504), "Description for Home Decor Product 7", 100, 70m, "Home Decor Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5505) },
                    { new Guid("3d28c9f3-e251-4200-a654-90a9250575ec"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5729), "Description for Toys Product 4", 100, 40m, "Toys Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5729) },
                    { new Guid("3f062321-e20d-4c20-a638-c094f7abad2d"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5343), "Description for Electronic Product 2", 100, 20m, "Electronic Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5343) },
                    { new Guid("40300fc7-deaf-4781-a4d6-18e604fc7abb"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5502), "Description for Home Decor Product 6", 100, 60m, "Home Decor Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5502) },
                    { new Guid("420f0a10-52e2-4715-a39e-b670073bb471"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5549), "Description for Home Decor Product 15", 100, 150m, "Home Decor Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5550) },
                    { new Guid("4589af9b-f36c-43a0-9a2a-1d1eeb9f2ab0"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5417), "Description for Clothing Product 5", 100, 50m, "Clothing Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5417) },
                    { new Guid("49dd3f1b-36c0-4644-ad16-c2f52ba5ebc5"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5482), "Description for Clothing Product 20", 100, 200m, "Clothing Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5482) },
                    { new Guid("5093093a-ede3-45ce-99e4-278f988c9ddc"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5692), "Description for Sports Product 19", 100, 190m, "Sports Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5693) },
                    { new Guid("5251efcf-e46d-40a9-8742-3d8ecd2cffc1"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5560), "Description for Home Decor Product 19", 100, 190m, "Home Decor Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5560) },
                    { new Guid("529d93a8-d66a-4015-80e4-b41a5f9f9ec9"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5407), "Description for Clothing Product 1", 100, 10m, "Clothing Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5407) },
                    { new Guid("560ee2df-2a14-4287-9a9c-128cdf1199f3"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5637), "Description for Books Product 19", 100, 190m, "Books Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5637) },
                    { new Guid("561037c6-e33a-48dd-8f36-917f15c417b5"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5580), "Description for Books Product 6", 100, 60m, "Books Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5581) },
                    { new Guid("57462ee0-52e0-4b74-8b5e-02e7bed72040"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5554), "Description for Home Decor Product 17", 100, 170m, "Home Decor Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5555) },
                    { new Guid("5a79923e-6b63-4abd-990e-67c01b6f4bb0"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5489), "Description for Home Decor Product 2", 100, 20m, "Home Decor Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5490) },
                    { new Guid("5c8a072f-d7e1-467a-8c41-7bd42a993fe6"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5496), "Description for Home Decor Product 4", 100, 40m, "Home Decor Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5497) },
                    { new Guid("5e8a77f0-efd2-476c-93d4-89c550fbf341"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5446), "Description for Clothing Product 7", 100, 70m, "Clothing Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5446) },
                    { new Guid("630c06c7-3b76-4d31-8473-65bf9455da30"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5486), "Description for Home Decor Product 1", 100, 10m, "Home Decor Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5487) },
                    { new Guid("6406f08c-29fc-4777-8b72-2395e900885d"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5455), "Description for Clothing Product 10", 100, 100m, "Clothing Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5456) },
                    { new Guid("65a6942c-17ca-4f2c-a166-5308ee04b1ec"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5578), "Description for Books Product 5", 100, 50m, "Books Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5578) },
                    { new Guid("663c3e9a-56b1-4627-a056-8facf89ed48b"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5687), "Description for Sports Product 17", 100, 170m, "Sports Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5687) },
                    { new Guid("69f5064e-8e11-4e13-b880-fd29b6e3e0ea"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5461), "Description for Clothing Product 12", 100, 120m, "Clothing Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5461) },
                    { new Guid("6d9e7ce2-ac63-4b86-b79f-1f67605cac67"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5643), "Description for Sports Product 1", 100, 10m, "Sports Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5643) },
                    { new Guid("6e01cdf5-c6ab-4539-83a0-66b0d4ce1fab"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5751), "Description for Toys Product 12", 100, 120m, "Toys Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5751) },
                    { new Guid("6ee34de1-133d-4433-96ba-ab62696bc7ba"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5568), "Description for Books Product 1", 100, 10m, "Books Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5569) },
                    { new Guid("72656154-0cb3-41ff-9a0f-de981f09e88e"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5458), "Description for Clothing Product 11", 100, 110m, "Clothing Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5458) },
                    { new Guid("73512b12-fee6-4cc6-bd1d-db982cea2518"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5472), "Description for Clothing Product 16", 100, 160m, "Clothing Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5472) },
                    { new Guid("748107e9-2b9b-482c-af17-c8feb2f3f8e6"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5599), "Description for Books Product 13", 100, 130m, "Books Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5600) },
                    { new Guid("75d40ba2-e971-4f06-979c-b6e0594637ee"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5742), "Description for Toys Product 9", 100, 90m, "Toys Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5743) },
                    { new Guid("7984a5a6-ddfb-4647-bbd4-b8098d2f2ecc"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5736), "Description for Toys Product 7", 100, 70m, "Toys Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5736) },
                    { new Guid("7fac6e79-c955-4290-b031-34f9f972e466"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5557), "Description for Home Decor Product 18", 100, 180m, "Home Decor Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5557) },
                    { new Guid("80bd50b9-3bef-49eb-9e69-cae7934582a8"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5677), "Description for Sports Product 13", 100, 130m, "Sports Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5677) },
                    { new Guid("81a64c3c-498d-4ed6-bec9-7ed1edaca993"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5573), "Description for Books Product 3", 100, 30m, "Books Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5573) },
                    { new Guid("8200ed0c-19c4-4793-ac87-71ccd4848705"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5468), "Description for Clothing Product 15", 100, 150m, "Clothing Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5468) },
                    { new Guid("82f3aa13-3688-4ca7-b644-dec6a224c53f"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5696), "Description for Sports Product 20", 100, 200m, "Sports Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5696) },
                    { new Guid("831c19f3-94f2-45a9-babb-5dc87a729975"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5722), "Description for Toys Product 1", 100, 10m, "Toys Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5722) },
                    { new Guid("84d709fb-fb09-4b0a-a8df-f571df2a5a58"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5655), "Description for Sports Product 5", 100, 50m, "Sports Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5655) },
                    { new Guid("86011dd2-150e-4e98-aaae-7b630b06b450"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5679), "Description for Sports Product 14", 100, 140m, "Sports Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5679) },
                    { new Guid("8a4c08e5-1de4-4342-ab6d-2ed13fd8418f"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5492), "Description for Home Decor Product 3", 100, 30m, "Home Decor Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5493) },
                    { new Guid("8bae7362-d57f-44c3-a9c7-6ff13840afc7"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5634), "Description for Books Product 18", 100, 180m, "Books Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5635) },
                    { new Guid("8f023257-2a94-4f63-8cbd-d60c0614758c"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5395), "Description for Electronic Product 19", 100, 190m, "Electronic Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5395) },
                    { new Guid("90084b35-06bf-430c-9e2b-646ee6687dd9"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5338), "Description for Electronic Product 1", 100, 10m, "Electronic Product 1", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5339) },
                    { new Guid("9032f4ea-02a1-45ae-b5df-d450036ef385"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5547), "Description for Home Decor Product 14", 100, 140m, "Home Decor Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5547) },
                    { new Guid("91b0f397-e8e5-4f22-85f8-2b53c139b2b7"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5748), "Description for Toys Product 11", 100, 110m, "Toys Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5749) },
                    { new Guid("91da1207-f1fc-41f1-add2-6906df760c35"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5604), "Description for Books Product 15", 100, 150m, "Books Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5604) },
                    { new Guid("920498fe-5fb8-47f6-828f-852edecd3688"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5670), "Description for Sports Product 11", 100, 110m, "Sports Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5671) },
                    { new Guid("948b8f83-0b55-4be9-ab1c-1d609845c876"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5509), "Description for Home Decor Product 9", 100, 90m, "Home Decor Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5510) },
                    { new Guid("993701cb-cb74-4966-b86c-e26b9016d984"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5589), "Description for Books Product 9", 100, 90m, "Books Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5589) },
                    { new Guid("9bc24033-f7e9-4e8b-aed7-a3557c24321d"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5507), "Description for Home Decor Product 8", 100, 80m, "Home Decor Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5507) },
                    { new Guid("9fdf4005-6498-4b3f-9942-70ed1dde56b3"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5668), "Description for Sports Product 10", 100, 100m, "Sports Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5668) },
                    { new Guid("a069123d-bcb0-4294-9660-ad5eb05aee49"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5660), "Description for Sports Product 7", 100, 70m, "Sports Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5660) },
                    { new Guid("a19ddddd-ef90-4188-a1db-76e7739e643f"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5382), "Description for Electronic Product 14", 100, 140m, "Electronic Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5382) },
                    { new Guid("a53a1e08-8f6e-4fe2-8fc1-d7d8857ba678"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5740), "Description for Toys Product 8", 100, 80m, "Toys Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5740) },
                    { new Guid("a59eaf8a-b531-44c4-854a-0e2b9eca4dd3"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5499), "Description for Home Decor Product 5", 100, 50m, "Home Decor Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5499) },
                    { new Guid("a75d3347-e6d8-4c3c-a5af-d79e90f59e81"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5648), "Description for Sports Product 3", 100, 30m, "Sports Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5649) },
                    { new Guid("ab12cfe9-0ba6-4bb2-a294-f2c2c9eb1cbf"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5665), "Description for Sports Product 9", 100, 90m, "Sports Product 9", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5665) },
                    { new Guid("abdc5d26-caf5-4b0c-b9f4-4ce8245eddb6"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5376), "Description for Electronic Product 12", 100, 120m, "Electronic Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5377) },
                    { new Guid("acc7805e-38c6-4c2d-ac3a-d20034a55dc2"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5415), "Description for Clothing Product 4", 100, 40m, "Clothing Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5415) },
                    { new Guid("adba6650-ea94-43ef-b623-4b2af68682d2"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5552), "Description for Home Decor Product 16", 100, 160m, "Home Decor Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5552) },
                    { new Guid("b7228cda-88ce-4c3b-8e20-9689728e9556"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5583), "Description for Books Product 7", 100, 70m, "Books Product 7", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5583) },
                    { new Guid("b7a5ba60-9d7c-4940-bcc2-0fa69c51f42b"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5587), "Description for Books Product 8", 100, 80m, "Books Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5587) },
                    { new Guid("c08db88a-3b05-4a06-8b9d-2e15875eb748"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5674), "Description for Sports Product 12", 100, 120m, "Sports Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5675) },
                    { new Guid("c6ca7139-90ff-43fb-b5d6-87a0287b4907"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5379), "Description for Electronic Product 13", 100, 130m, "Electronic Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5380) },
                    { new Guid("c915eda6-e763-4268-9769-2e30ac8b69c2"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5384), "Description for Electronic Product 15", 100, 150m, "Electronic Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5385) },
                    { new Guid("caa2abc6-fd0e-4049-9703-7e34acd0cbb0"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5479), "Description for Clothing Product 19", 100, 190m, "Clothing Product 19", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5480) },
                    { new Guid("cad61d20-31d3-4f5b-9299-481e210ea40e"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5607), "Description for Books Product 16", 100, 160m, "Books Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5608) },
                    { new Guid("cb402e26-b26f-41c9-bb64-f6e69a96ac24"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5346), "Description for Electronic Product 3", 100, 30m, "Electronic Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5346) },
                    { new Guid("cc24807a-299d-4471-b4a4-fb0e40aa68f1"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5724), "Description for Toys Product 2", 100, 20m, "Toys Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5725) },
                    { new Guid("d05a8e4f-9fe1-4309-989d-09070a97d99e"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5443), "Description for Clothing Product 6", 100, 60m, "Clothing Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5443) },
                    { new Guid("d0865695-3f67-4e1f-bd21-74066af453ee"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5646), "Description for Sports Product 2", 100, 20m, "Sports Product 2", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5646) },
                    { new Guid("d1e931a8-748f-4537-be63-30eb613900e2"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5765), "Description for Toys Product 17", 100, 170m, "Toys Product 17", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5765) },
                    { new Guid("d334ac1d-5bde-4143-b2f3-e0b1a907123b"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5602), "Description for Books Product 14", 100, 140m, "Books Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5602) },
                    { new Guid("d4502ebb-c721-412f-b64c-a7c016ea4727"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5563), "Description for Home Decor Product 20", 100, 200m, "Home Decor Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5564) },
                    { new Guid("d5b9ed1f-49ab-48f6-b987-2c57354402bd"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5772), "Description for Toys Product 20", 100, 200m, "Toys Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5772) },
                    { new Guid("d61f0506-9629-4653-b867-c10e8b384388"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5681), "Description for Sports Product 15", 100, 150m, "Sports Product 15", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5682) },
                    { new Guid("d9d824a1-b99c-407c-8924-3397af2fdab8"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5595), "Description for Books Product 11", 100, 110m, "Books Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5595) },
                    { new Guid("da58b569-d2f0-47f6-aa01-e228539d8b1d"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5762), "Description for Toys Product 16", 100, 160m, "Toys Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5763) },
                    { new Guid("dfb59bfa-8f8a-4f53-8568-9308cc0a7865"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5477), "Description for Clothing Product 18", 100, 180m, "Clothing Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("e1e2916b-4f8d-41fc-9738-faa2e00d6baf"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5731), "Description for Toys Product 5", 100, 50m, "Toys Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5731) },
                    { new Guid("e1f298b5-560f-4ee7-ae60-4f273a5513d7"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5684), "Description for Sports Product 16", 100, 160m, "Sports Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5685) },
                    { new Guid("e5798534-13fe-4869-9da6-33e8eeabde0c"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5756), "Description for Toys Product 14", 100, 140m, "Toys Product 14", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5756) },
                    { new Guid("e5a240d1-312c-4ecc-98a1-045512c17166"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5387), "Description for Electronic Product 16", 100, 160m, "Electronic Product 16", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5387) },
                    { new Guid("e6533686-fecd-4b73-8b6d-a0a8a575603e"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5355), "Description for Electronic Product 5", 100, 50m, "Electronic Product 5", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5355) },
                    { new Guid("e6c3bc57-51f3-40f7-b37e-3117c7a8c1aa"), new Guid("9f6c3e8f-1be9-4a1a-b1a4-7515c526c21e"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5597), "Description for Books Product 12", 100, 120m, "Books Product 12", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5597) },
                    { new Guid("e7eb41b0-725d-446f-a69f-7f2f7cec096c"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5746), "Description for Toys Product 10", 100, 100m, "Toys Product 10", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5746) },
                    { new Guid("e90c995e-ca77-471a-b282-8f4fa527a8c3"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5463), "Description for Clothing Product 13", 100, 130m, "Clothing Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5463) },
                    { new Guid("e9b9bfaf-84e7-4c27-a4a8-2452b58f08bd"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5767), "Description for Toys Product 18", 100, 180m, "Toys Product 18", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5768) },
                    { new Guid("eee19003-ea9c-4f22-ab5e-d0093c0a1be6"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5662), "Description for Sports Product 8", 100, 80m, "Sports Product 8", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5663) },
                    { new Guid("f0586c2c-dd93-44cc-b50b-24690c5fa69b"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5727), "Description for Toys Product 3", 100, 30m, "Toys Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5727) },
                    { new Guid("f2f70645-9c40-4fb2-a135-5329b54bb1f4"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5545), "Description for Home Decor Product 13", 100, 130m, "Home Decor Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5545) },
                    { new Guid("f3bb33a2-1691-4546-968d-157171241ba6"), new Guid("7d22dca8-1c51-45c6-bdf6-31d322566eeb"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5754), "Description for Toys Product 13", 100, 130m, "Toys Product 13", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5754) },
                    { new Guid("f40943a4-8cc0-4925-ba04-dc7d77274805"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5399), "Description for Electronic Product 20", 100, 200m, "Electronic Product 20", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5399) },
                    { new Guid("f529b754-8c7e-4d5d-a1d0-a5031e29ea68"), new Guid("1d5a61bb-c67e-4cdf-83ed-1cda6288f8fc"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5652), "Description for Sports Product 4", 100, 40m, "Sports Product 4", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5653) },
                    { new Guid("f5a4d235-d8a7-40c7-bb4e-db7b49626a16"), new Guid("ee65c3f1-2529-46bb-8c82-d3d06d66d956"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5538), "Description for Home Decor Product 11", 100, 110m, "Home Decor Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5538) },
                    { new Guid("f6511fe3-7257-4c4a-8040-dba031302421"), new Guid("840b0e09-1529-4507-b77a-0c96f376c59b"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5412), "Description for Clothing Product 3", 100, 30m, "Clothing Product 3", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5413) },
                    { new Guid("fd9846f5-b5ba-4c42-b458-f0422e0fd42d"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5359), "Description for Electronic Product 6", 100, 60m, "Electronic Product 6", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5359) },
                    { new Guid("fddf863a-669f-4b6f-b898-e851bc48b7b7"), new Guid("37dcf000-7457-4f4c-9c10-7613681a39e0"), new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5372), "Description for Electronic Product 11", 100, 110m, "Electronic Product 11", new DateTime(2023, 12, 27, 9, 59, 1, 372, DateTimeKind.Utc).AddTicks(5372) }
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
