using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class AddAccountAndStatusLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EurobonusAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EurobonusAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EurobonusStatusLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EurobonusStatusLevel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EurobonusStatusLevel",
                columns: new[] { "Id", "StatusLevel" },
                values: new object[,]
                {
                    { 0, "Basic" },
                    { 1, "Silver" },
                    { 2, "Gold" },
                    { 3, "Diamond" },
                    { 4, "Pandion" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EurobonusAccount");

            migrationBuilder.DropTable(
                name: "EurobonusStatusLevel");
        }
    }
}
