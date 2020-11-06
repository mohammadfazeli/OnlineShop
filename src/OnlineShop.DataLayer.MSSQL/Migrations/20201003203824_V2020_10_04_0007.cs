using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2020_10_04_0007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "ItemSection",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSection_ProductDetailId",
                table: "ItemSection",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSection_ProductDetail_ProductDetailId",
                table: "ItemSection",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSection_ProductDetail_ProductDetailId",
                table: "ItemSection");

            migrationBuilder.DropIndex(
                name: "IX_ItemSection_ProductDetailId",
                table: "ItemSection");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ItemSection");
        }
    }
}
