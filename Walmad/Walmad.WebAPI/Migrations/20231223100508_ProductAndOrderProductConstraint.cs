using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductAndOrderProductConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "category_id1",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id1",
                table: "products",
                column: "category_id1");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Product_Price_Positive",
                table: "products",
                sql: "price >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_OrderProduct_Quantity_Positive",
                table: "order_products",
                sql: "quantity >= 0");

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id1",
                table: "products",
                column: "category_id1",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_category_id1",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Product_Price_Positive",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_OrderProduct_Quantity_Positive",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "category_id1",
                table: "products");
        }
    }
}
