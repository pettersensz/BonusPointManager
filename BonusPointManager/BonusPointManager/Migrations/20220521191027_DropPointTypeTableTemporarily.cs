using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class DropPointTypeTableTemporarily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EurobonusTransaction_EurobonusPointType_PointTypeId",
                table: "EurobonusTransaction");

            migrationBuilder.DropTable(
                name: "EurobonusPointType");

            migrationBuilder.DropIndex(
                name: "IX_EurobonusTransaction_PointTypeId",
                table: "EurobonusTransaction");

            migrationBuilder.RenameColumn(
                name: "PointTypeId",
                table: "EurobonusTransaction",
                newName: "PointType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PointType",
                table: "EurobonusTransaction",
                newName: "PointTypeId");

            migrationBuilder.CreateTable(
                name: "EurobonusPointType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EurobonusPointType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EurobonusTransaction_PointTypeId",
                table: "EurobonusTransaction",
                column: "PointTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EurobonusTransaction_EurobonusPointType_PointTypeId",
                table: "EurobonusTransaction",
                column: "PointTypeId",
                principalTable: "EurobonusPointType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
