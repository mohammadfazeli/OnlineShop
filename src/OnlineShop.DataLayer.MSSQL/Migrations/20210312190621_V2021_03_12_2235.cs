using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2021_03_12_2235 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemSectionType",
                table: "ItemSection");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "ItemSection",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSection_SectionId",
                table: "ItemSection",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSection_Section_SectionId",
                table: "ItemSection",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSection_Section_SectionId",
                table: "ItemSection");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropIndex(
                name: "IX_ItemSection_SectionId",
                table: "ItemSection");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "ItemSection");

            migrationBuilder.AddColumn<int>(
                name: "itemSectionType",
                table: "ItemSection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
