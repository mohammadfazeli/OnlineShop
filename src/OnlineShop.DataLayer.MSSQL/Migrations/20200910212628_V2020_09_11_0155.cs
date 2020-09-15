using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2020_09_11_0155 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "ProductDetailSpecification");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "ProductDetailSpecification");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProductDetailSpecification");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ProductDetailSpecification");

            migrationBuilder.AddColumn<string>(
                name: "SpecificationName",
                table: "ProductDetailSpecification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecificationType",
                table: "ProductDetailSpecification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecificationValue",
                table: "ProductDetailSpecification",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductSpecification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    SpecificationName = table.Column<string>(nullable: true),
                    SpecificationType = table.Column<int>(nullable: false),
                    SpecificationValue = table.Column<string>(nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecification_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecification_ProductId",
                table: "ProductSpecification",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "SpecificationName",
                table: "ProductDetailSpecification");

            migrationBuilder.DropColumn(
                name: "SpecificationType",
                table: "ProductDetailSpecification");

            migrationBuilder.DropColumn(
                name: "SpecificationValue",
                table: "ProductDetailSpecification");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "ProductDetailSpecification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "ProductDetailSpecification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "ProductDetailSpecification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "ProductDetailSpecification",
                type: "int",
                nullable: true);
        }
    }
}
