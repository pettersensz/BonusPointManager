using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class RemovePreviousLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EurobonusTransactions_EurobonusAccounts_EurobonusAccountId",
                table: "EurobonusTransactions");

            migrationBuilder.DropIndex(
                name: "IX_EurobonusTransactions_EurobonusAccountId",
                table: "EurobonusTransactions");

            migrationBuilder.DropColumn(
                name: "EurobonusAccountId",
                table: "EurobonusTransactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EurobonusAccountId",
                table: "EurobonusTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EurobonusTransactions_EurobonusAccountId",
                table: "EurobonusTransactions",
                column: "EurobonusAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_EurobonusTransactions_EurobonusAccounts_EurobonusAccountId",
                table: "EurobonusTransactions",
                column: "EurobonusAccountId",
                principalTable: "EurobonusAccounts",
                principalColumn: "Id");
        }
    }
}
