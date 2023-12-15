using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_image_products_product_id1",
                table: "product_image");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_category_id1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_product_image_product_id1",
                table: "product_image");

            migrationBuilder.DropColumn(
                name: "category_id1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_id1",
                table: "product_image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "category_id1",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "product_id1",
                table: "product_image",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id1",
                table: "products",
                column: "category_id1");

            migrationBuilder.CreateIndex(
                name: "ix_product_image_product_id1",
                table: "product_image",
                column: "product_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_product_image_products_product_id1",
                table: "product_image",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id1",
                table: "products",
                column: "category_id1",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
