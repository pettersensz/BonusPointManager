using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class RenameDbSetsToPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusTransaction",
                table: "EurobonusTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusStatusLevel",
                table: "EurobonusStatusLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusPointType",
                table: "EurobonusPointType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusAccount",
                table: "EurobonusAccount");

            migrationBuilder.RenameTable(
                name: "EurobonusTransaction",
                newName: "EurobonusTransactions");

            migrationBuilder.RenameTable(
                name: "EurobonusStatusLevel",
                newName: "EurobonusStatusLevels");

            migrationBuilder.RenameTable(
                name: "EurobonusPointType",
                newName: "EurobonusPointTypes");

            migrationBuilder.RenameTable(
                name: "EurobonusAccount",
                newName: "EurobonusAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusTransactions",
                table: "EurobonusTransactions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusStatusLevels",
                table: "EurobonusStatusLevels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusPointTypes",
                table: "EurobonusPointTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusAccounts",
                table: "EurobonusAccounts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusTransactions",
                table: "EurobonusTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusStatusLevels",
                table: "EurobonusStatusLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusPointTypes",
                table: "EurobonusPointTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EurobonusAccounts",
                table: "EurobonusAccounts");

            migrationBuilder.RenameTable(
                name: "EurobonusTransactions",
                newName: "EurobonusTransaction");

            migrationBuilder.RenameTable(
                name: "EurobonusStatusLevels",
                newName: "EurobonusStatusLevel");

            migrationBuilder.RenameTable(
                name: "EurobonusPointTypes",
                newName: "EurobonusPointType");

            migrationBuilder.RenameTable(
                name: "EurobonusAccounts",
                newName: "EurobonusAccount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusTransaction",
                table: "EurobonusTransaction",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusStatusLevel",
                table: "EurobonusStatusLevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusPointType",
                table: "EurobonusPointType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EurobonusAccount",
                table: "EurobonusAccount",
                column: "Id");
        }
    }
}
