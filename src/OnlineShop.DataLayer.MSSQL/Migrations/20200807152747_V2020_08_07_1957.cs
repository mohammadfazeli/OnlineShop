using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2020_08_07_1957 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForeignName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignName",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationCode",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartNumber",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignName",
                table: "Model",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "Model",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignName",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "Color",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForeignName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ForeignName",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "OperationCode",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PartNumber",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ForeignName",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "ForeignName",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Color");
        }
    }
}
