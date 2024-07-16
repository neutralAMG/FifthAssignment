using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FifthAssignment.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class allownullsInTransactionsTablesanother : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountToId",
                schema: "Transaction",
                table: "ExpressPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountToId",
                schema: "Transaction",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountToId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountToId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountToId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountToId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountToId",
                schema: "Transaction",
                table: "ExpressPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountToId",
                schema: "Transaction",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountToId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountToId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountToId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountToId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }
    }
}
