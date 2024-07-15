using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FifthAssignment.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IdentifierNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditLimit = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IdentifierNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IdentifierNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserBeneficiaryBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_BankAccounts_UserBeneficiaryBankAccountId",
                        column: x => x.UserBeneficiaryBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryPayments",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    UserBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeneficiaryBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiaryPayments_BankAccounts_BeneficiaryBankAccountId",
                        column: x => x.BeneficiaryBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BeneficiaryPayments_BankAccounts_UserBankAccountId",
                        column: x => x.UserBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpressPayments",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    BankAccountFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpressPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpressPayments_BankAccounts_BankAccountFromId",
                        column: x => x.BankAccountFromId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpressPayments_BankAccounts_BankAccountToId",
                        column: x => x.BankAccountToId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    UserAccountFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccountToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_BankAccounts_UserAccountFromId",
                        column: x => x.UserAccountFromId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfers_BankAccounts_UserAccountToId",
                        column: x => x.UserAccountToId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditcardPayments",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    UserBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditcardPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditcardPayments_BankAccounts_UserBankAccountId",
                        column: x => x.UserBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditcardPayments_CreditCards_UserCreditCardId",
                        column: x => x.UserCreditCardId,
                        principalSchema: "Transaction",
                        principalTable: "CreditCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoneyAdvances",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    UserCreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyAdvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyAdvances_BankAccounts_UserBankAccountId",
                        column: x => x.UserBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MoneyAdvances_CreditCards_UserCreditCardId",
                        column: x => x.UserCreditCardId,
                        principalSchema: "Transaction",
                        principalTable: "CreditCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanPayments",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    UserBankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanPayments_BankAccounts_UserBankAccountId",
                        column: x => x.UserBankAccountId,
                        principalSchema: "Transaction",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanPayments_Loans_UserLoanId",
                        column: x => x.UserLoanId,
                        principalSchema: "Transaction",
                        principalTable: "Loans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    SpecificTransactionDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_PaymentTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "Transaction",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "Transaction",
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalSchema: "Transaction",
                        principalTable: "TransactionDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Transaction",
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Express Payment" },
                    { 2, "Beneficiary Payment" },
                    { 3, "CreditCard Payment" },
                    { 4, "Loan Payment" },
                    { 5, "Transfer" },
                    { 6, "Money Advance" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                schema: "Transaction",
                table: "BankAccounts",
                column: "UserId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_UserBeneficiaryBankAccountId",
                schema: "Transaction",
                table: "Beneficiaries",
                column: "UserBeneficiaryBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_UserId",
                schema: "Transaction",
                table: "Beneficiaries",
                column: "UserId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryPayments_BeneficiaryBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments",
                column: "BeneficiaryBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryPayments_UserBankAccountId",
                schema: "Transaction",
                table: "BeneficiaryPayments",
                column: "UserBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CreditcardPayments_UserBankAccountId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CreditcardPayments_UserCreditCardId",
                schema: "Transaction",
                table: "CreditcardPayments",
                column: "UserCreditCardId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                schema: "Transaction",
                table: "CreditCards",
                column: "UserId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ExpressPayments_BankAccountFromId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountFromId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ExpressPayments_BankAccountToId",
                schema: "Transaction",
                table: "ExpressPayments",
                column: "BankAccountToId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayments_UserBankAccountId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayments_UserLoanId",
                schema: "Transaction",
                table: "LoanPayments",
                column: "UserLoanId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                schema: "Transaction",
                table: "Loans",
                column: "UserId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAdvances_UserBankAccountId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserBankAccountId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAdvances_UserCreditCardId",
                schema: "Transaction",
                table: "MoneyAdvances",
                column: "UserCreditCardId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_SpecificTransactionDetailId",
                schema: "Transaction",
                table: "TransactionDetails",
                column: "SpecificTransactionDetailId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionTypeId",
                schema: "Transaction",
                table: "TransactionDetails",
                column: "TransactionTypeId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionDetailId",
                schema: "Transaction",
                table: "Transactions",
                column: "TransactionDetailId",
                unique: true,
                filter: "[TransactionDetailId] IS NOT NULL")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                schema: "Transaction",
                table: "Transactions",
                column: "TransactionTypeId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_UserAccountFromId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountFromId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_UserAccountToId",
                schema: "Transaction",
                table: "Transfers",
                column: "UserAccountToId")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiaries",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "BeneficiaryPayments",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "CreditcardPayments",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "ExpressPayments",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "LoanPayments",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "MoneyAdvances",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Transfers",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Loans",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "CreditCards",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionDetails",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "PaymentTypes",
                schema: "Transaction");
        }
    }
}
