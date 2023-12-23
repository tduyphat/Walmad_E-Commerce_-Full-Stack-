using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteConstraintAddOrderRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_Product_Price_Positive",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_OrderProduct_Quantity_Positive",
                table: "order_products");

            migrationBuilder.AddColumn<Guid>(
                name: "order_id1",
                table: "order_products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_products_order_id1",
                table: "order_products",
                column: "order_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_orders_order_id1",
                table: "order_products",
                column: "order_id1",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_products_orders_order_id1",
                table: "order_products");

            migrationBuilder.DropIndex(
                name: "ix_order_products_order_id1",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "order_id1",
                table: "order_products");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Product_Price_Positive",
                table: "products",
                sql: "price >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_OrderProduct_Quantity_Positive",
                table: "order_products",
                sql: "quantity >= 0");
        }
    }
}
