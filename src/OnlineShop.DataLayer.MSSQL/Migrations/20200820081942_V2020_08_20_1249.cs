using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DataLayer.MSSQL.Migrations
{
    public partial class V2020_08_20_1249 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtentionFile",
                table: "Attachment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtentionFile",
                table: "Attachment");
        }
    }
}
