

namespace FifthAssignment.Core.Application.Models.BankAccountsModels
{
	public class SaveBankAccountModel
	{
		public double Amount { get; set; }
		public string IdentifierNumber { get; set; }
		public string UserId { get; set; }
		public bool IsMain { get; set; }

	}
}
