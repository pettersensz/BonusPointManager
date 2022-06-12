using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class LinkRunwayHeadingToRunwayStep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading1Id",
                table: "Runways");

            migrationBuilder.DropForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading2Id",
                table: "Runways");

            migrationBuilder.DropIndex(
                name: "IX_Runways_RunwayHeading1Id",
                table: "Runways");

            migrationBuilder.DropIndex(
                name: "IX_Runways_RunwayHeading2Id",
                table: "Runways");

            migrationBuilder.DropColumn(
                name: "RunwayHeading1Id",
                table: "Runways");

            migrationBuilder.DropColumn(
                name: "RunwayHeading2Id",
                table: "Runways");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunwayHeading1Id",
                table: "Runways",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunwayHeading2Id",
                table: "Runways",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runways_RunwayHeading1Id",
                table: "Runways",
                column: "RunwayHeading1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Runways_RunwayHeading2Id",
                table: "Runways",
                column: "RunwayHeading2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading1Id",
                table: "Runways",
                column: "RunwayHeading1Id",
                principalTable: "RunwayHeadings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading2Id",
                table: "Runways",
                column: "RunwayHeading2Id",
                principalTable: "RunwayHeadings",
                principalColumn: "Id");
        }
    }
}
