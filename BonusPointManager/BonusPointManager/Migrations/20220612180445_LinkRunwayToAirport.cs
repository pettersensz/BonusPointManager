using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class LinkRunwayToAirport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runways_Airports_AirportId",
                table: "Runways");

            migrationBuilder.AlterColumn<int>(
                name: "AirportId",
                table: "Runways",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Runways_Airports_AirportId",
                table: "Runways",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runways_Airports_AirportId",
                table: "Runways");

            migrationBuilder.AlterColumn<int>(
                name: "AirportId",
                table: "Runways",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Runways_Airports_AirportId",
                table: "Runways",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");
        }
    }
}
