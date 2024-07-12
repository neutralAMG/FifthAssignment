
namespace FifthAssignment.Core.Application.Models.BankAccountsModels
{
	public class BankAccountModel
	{
		public Guid Id { get; set; }	
		public string UserId { get; set; }
		public double Amount { get; set; }
		public string IdentifierNumber { get; set; }
		public bool IsMain { get; set; }
	}
}
