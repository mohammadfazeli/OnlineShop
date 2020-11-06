using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2020_11_06_1604 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSection_Product_ProductId",
                table: "ItemSection");

            migrationBuilder.DropIndex(
                name: "IX_ItemSection_ProductId",
                table: "ItemSection");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ItemSection");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductSpecification",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductSpecification");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ItemSection",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSection_ProductId",
                table: "ItemSection",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSection_Product_ProductId",
                table: "ItemSection",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
