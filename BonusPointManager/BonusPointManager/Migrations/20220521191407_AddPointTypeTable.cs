using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class AddPointTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EurobonusPointType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PointType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EurobonusPointType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EurobonusPointType",
                columns: new[] { "Id", "PointType" },
                values: new object[] { 0, "Extra" });

            migrationBuilder.InsertData(
                table: "EurobonusPointType",
                columns: new[] { "Id", "PointType" },
                values: new object[] { 1, "Basic" });

            migrationBuilder.InsertData(
                table: "EurobonusPointType",
                columns: new[] { "Id", "PointType" },
                values: new object[] { 2, "Status" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EurobonusPointType");
        }
    }
}
