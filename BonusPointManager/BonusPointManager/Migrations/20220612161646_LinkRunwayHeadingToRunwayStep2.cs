using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class LinkRunwayHeadingToRunwayStep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunwayId",
                table: "RunwayHeadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RunwayHeadings_RunwayId",
                table: "RunwayHeadings",
                column: "RunwayId");

            migrationBuilder.AddForeignKey(
                name: "FK_RunwayHeadings_Runways_RunwayId",
                table: "RunwayHeadings",
                column: "RunwayId",
                principalTable: "Runways",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunwayHeadings_Runways_RunwayId",
                table: "RunwayHeadings");

            migrationBuilder.DropIndex(
                name: "IX_RunwayHeadings_RunwayId",
                table: "RunwayHeadings");

            migrationBuilder.DropColumn(
                name: "RunwayId",
                table: "RunwayHeadings");
        }
    }
}
