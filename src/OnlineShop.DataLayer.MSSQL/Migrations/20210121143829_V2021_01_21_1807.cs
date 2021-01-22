using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2021_01_21_1807:Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyDetail_ProductDetail_ProductDetailId",
                table: "BuyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ExitDetail_ProductDetail_ProductDetailId",
                table: "ExitDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSection_ProductDetail_ProductDetailId",
                table: "ItemSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequestDetail_ProductDetail_ProductDetailId",
                table: "ProductRequestDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "ProductDetailSize");

            migrationBuilder.DropTable(
                name: "ProductDetailSpecification");

            migrationBuilder.DropTable(
                name: "ProductPriceModificatin");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductRequestDetail_ProductDetailId",
                table: "ProductRequestDetail");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_ItemSection_ProductDetailId",
                table: "ItemSection");

            migrationBuilder.DropIndex(
                name: "IX_ExitDetail_ProductDetailId",
                table: "ExitDetail");

            migrationBuilder.DropIndex(
                name: "IX_BuyDetail_ProductDetailId",
                table: "BuyDetail");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ProductRequestDetail");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ItemSection");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ExitDetail");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "BuyDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductRequestDetail",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ItemSection",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ExitDetail",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "BuyDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    ColorId = table.Column<Guid>(nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColor_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductColor_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    ModelId = table.Column<Guid>(nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModel_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModel_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSalePrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    OldPrice = table.Column<decimal>(type: "decimal(18, 6)",nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18, 6)",nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSalePrice",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSalePrice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    SizeId = table.Column<Guid>(nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSize_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSize_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequestDetail_ProductId",
                table: "ProductRequestDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ModelId",
                table: "Product",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProviderId",
                table: "Product",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSection_ProductId",
                table: "ItemSection",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExitDetail_ProductId",
                table: "ExitDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetail_ProductId",
                table: "BuyDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ColorId",
                table: "ProductColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ProductId",
                table: "ProductColor",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_ModelId",
                table: "ProductModel",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_ProductId",
                table: "ProductModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSalePrice_ProductId",
                table: "ProductSalePrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSize",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyDetail_Product_ProductId",
                table: "BuyDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExitDetail_Product_ProductId",
                table: "ExitDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSection_Product_ProductId",
                table: "ItemSection",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Model_ModelId",
                table: "Product",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Provider_ProviderId",
                table: "Product",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequestDetail_Product_ProductId",
                table: "ProductRequestDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyDetail_Product_ProductId",
                table: "BuyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ExitDetail_Product_ProductId",
                table: "ExitDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSection_Product_ProductId",
                table: "ItemSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Model_ModelId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Provider_ProviderId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequestDetail_Product_ProductId",
                table: "ProductRequestDetail");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "ProductSalePrice");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductRequestDetail_ProductId",
                table: "ProductRequestDetail");

            migrationBuilder.DropIndex(
                name: "IX_Product_ModelId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProviderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_ItemSection_ProductId",
                table: "ItemSection");

            migrationBuilder.DropIndex(
                name: "IX_ExitDetail_ProductId",
                table: "ExitDetail");

            migrationBuilder.DropIndex(
                name: "IX_BuyDetail_ProductId",
                table: "BuyDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductRequestDetail");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ItemSection");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ExitDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BuyDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "ProductRequestDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "ItemSection",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "ExitDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailId",
                table: "BuyDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)",maxLength: 450,nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category",x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    ForeignName = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    OperationCode = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    PartNumber = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part",x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    ColorId = table.Column<Guid>(type: "uniqueidentifier",nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier",nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier",nullable: true),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier",nullable: true),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailSize",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailSize_ProductDetail_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetailSize_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailSpecification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier",nullable: true),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    SpecificationType = table.Column<int>(type: "int",nullable: false),
                    SpecificationValue = table.Column<string>(type: "nvarchar(max)",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailSpecification",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailSpecification_ProductDetail_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceModificatin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2",nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int",nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)",nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2",nullable: false),
                    InActive = table.Column<bool>(type: "bit",nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit",nullable: false),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)",maxLength: 1000,nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)",maxLength: 255,nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int",nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2",nullable: true),
                    NewPrice = table.Column<decimal>(type: "decimal(18, 6)",nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18, 6)",nullable: false),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceModificatin",x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceModificatin_ProductDetail_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequestDetail_ProductDetailId",
                table: "ProductRequestDetail",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSection_ProductDetailId",
                table: "ItemSection",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ExitDetail_ProductDetailId",
                table: "ExitDetail",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetail_ProductDetailId",
                table: "BuyDetail",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ColorId",
                table: "ProductDetail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ModelId",
                table: "ProductDetail",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductId",
                table: "ProductDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProviderId",
                table: "ProductDetail",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailSize_ProductDetailId",
                table: "ProductDetailSize",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailSize_SizeId",
                table: "ProductDetailSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailSpecification_ProductDetailId",
                table: "ProductDetailSpecification",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceModificatin_ProductDetailId",
                table: "ProductPriceModificatin",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyDetail_ProductDetail_ProductDetailId",
                table: "BuyDetail",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExitDetail_ProductDetail_ProductDetailId",
                table: "ExitDetail",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSection_ProductDetail_ProductDetailId",
                table: "ItemSection",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequestDetail_ProductDetail_ProductDetailId",
                table: "ProductRequestDetail",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}