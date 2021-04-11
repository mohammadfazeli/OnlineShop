using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2021_04_09_1619 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PercentDiscount = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    RegisterOrderDate = table.Column<DateTime>(nullable: false),
                    RegisterUserId = table.Column<int>(nullable: true),
                    CouponId = table.Column<Guid>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TotalAfterDiscount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    EndFee = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Lock = table.Column<bool>(nullable: false),
                    IsPayment = table.Column<bool>(nullable: false),
                    PaymentResult = table.Column<string>(nullable: true),
                    FactorNo = table.Column<int>(nullable: true),
                    BankFollowupNo = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AppUsers_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    PercentDiscount = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TotalAfterDiscount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    EndFee = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
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
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CouponId",
                table: "Order",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RegisterUserId",
                table: "Order",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Coupon");
        }
    }
}
