using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class FixRunwayLengthTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LenghtFt",
                table: "Runways",
                newName: "LengthFt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LengthFt",
                table: "Runways",
                newName: "LenghtFt");
        }
    }
}
