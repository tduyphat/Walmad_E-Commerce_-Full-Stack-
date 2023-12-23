using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Walmad.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "product_id1",
                table: "reviews",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id1",
                table: "reviews",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_reviews_product_id1",
                table: "reviews",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id1",
                table: "reviews",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_products_product_id1",
                table: "reviews",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_user_id1",
                table: "reviews",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviews_products_product_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_user_id1",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_reviews_product_id1",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_reviews_user_id1",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "product_id1",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "reviews");
        }
    }
}
