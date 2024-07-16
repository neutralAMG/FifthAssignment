using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FifthAssignment.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class allownullsInTransactionsTablesSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "Transaction",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "Transaction",
                table: "CreditCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "Transaction",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "Transaction",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "Transaction",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "Transaction",
                table: "BankAccounts");
        }
    }
}
