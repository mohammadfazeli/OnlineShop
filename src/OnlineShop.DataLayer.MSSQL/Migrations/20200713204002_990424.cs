using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class _990424 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "uniqueId",
                table: "Parts");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Parts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "InActive",
                table: "Parts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Parts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "InActive",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Parts");

            migrationBuilder.AddColumn<Guid>(
                name: "uniqueId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "uniqueId");
        }
    }
}
