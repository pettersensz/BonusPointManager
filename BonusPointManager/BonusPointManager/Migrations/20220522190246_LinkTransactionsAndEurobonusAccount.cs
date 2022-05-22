using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusPointManager.Migrations
{
    public partial class LinkTransactionsAndEurobonusAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "EurobonusTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EurobonusTransactions_AccountId",
                table: "EurobonusTransactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_EurobonusTransactions_EurobonusAccounts_AccountId",
                table: "EurobonusTransactions",
                column: "AccountId",
                principalTable: "EurobonusAccounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EurobonusTransactions_EurobonusAccounts_AccountId",
                table: "EurobonusTransactions");

            migrationBuilder.DropIndex(
                name: "IX_EurobonusTransactions_AccountId",
                table: "EurobonusTransactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "EurobonusTransactions");
        }
    }
}
