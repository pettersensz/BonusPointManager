using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class AddRunwayHeadingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heading",
                table: "Runways",
                newName: "RunwaySurface");

            migrationBuilder.RenameColumn(
                name: "DisplacedThresholdFt",
                table: "Runways",
                newName: "LenghtFt");

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

            migrationBuilder.CreateTable(
                name: "RunwayHeadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadingDeg = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    DisplacedThresholdFt = table.Column<int>(type: "int", nullable: false),
                    LatitudeDeg = table.Column<decimal>(type: "decimal(17,14)", nullable: false),
                    LongitudeDeg = table.Column<decimal>(type: "decimal(17,14)", nullable: false),
                    ElevationFt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunwayHeadings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunwaySurfaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SurfaceType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunwaySurfaces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RunwaySurfaces",
                columns: new[] { "Id", "SurfaceType" },
                values: new object[,]
                {
                    { 0, "Asphalt" },
                    { 1, "Concrete" },
                    { 2, "Gravel" },
                    { 3, "Grass" },
                    { 4, "GravelAndGrass" },
                    { 5, "Unknown" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading1Id",
                table: "Runways");

            migrationBuilder.DropForeignKey(
                name: "FK_Runways_RunwayHeadings_RunwayHeading2Id",
                table: "Runways");

            migrationBuilder.DropTable(
                name: "RunwayHeadings");

            migrationBuilder.DropTable(
                name: "RunwaySurfaces");

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

            migrationBuilder.RenameColumn(
                name: "RunwaySurface",
                table: "Runways",
                newName: "Heading");

            migrationBuilder.RenameColumn(
                name: "LenghtFt",
                table: "Runways",
                newName: "DisplacedThresholdFt");
        }
    }
}
