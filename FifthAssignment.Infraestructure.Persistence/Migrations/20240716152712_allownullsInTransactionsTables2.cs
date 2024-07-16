using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FifthAssignment.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class allownullsInTransactionsTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditcardPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "CreditcardPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditcardPayments_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "CreditcardPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountFromId",
                schema: "Transaction",
                table: "ExpressPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_Loans_UserLoanId",
                schema: "Transaction",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAdvances_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "MoneyAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAdvances_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "MoneyAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountFromId",
                schema: "Transaction",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditcardPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditcardPayments_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserCreditCardId",
                principalSchema: "Transaction",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountFromId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountFromId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_Loans_UserLoanId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserLoanId",
                principalSchema: "Transaction",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAdvances_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAdvances_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserCreditCardId",
                principalSchema: "Transaction",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountFromId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountFromId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditcardPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "CreditcardPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditcardPayments_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "CreditcardPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountFromId",
                schema: "Transaction",
                table: "ExpressPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_Loans_UserLoanId",
                schema: "Transaction",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAdvances_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "MoneyAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAdvances_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "MoneyAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountFromId",
                schema: "Transaction",
                table: "Transfers");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditcardPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditcardPayments_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserCreditCardId",
                principalSchema: "Transaction",
                principalTable: "CreditCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpressPayments_BankAccounts_BankAccountFromId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountFromId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_Loans_UserLoanId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserLoanId",
                principalSchema: "Transaction",
                principalTable: "Loans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAdvances_BankAccounts_UserBankAccountId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserBankAccountId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAdvances_CreditCards_UserCreditCardId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserCreditCardId",
                principalSchema: "Transaction",
                principalTable: "CreditCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_BankAccounts_UserAccountFromId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountFromId",
                principalSchema: "Transaction",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }
    }
}
