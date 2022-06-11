using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class AddRunwayWidth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WidthFt",
                table: "Runways",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WidthFt",
                table: "Runways");
        }
    }
}
