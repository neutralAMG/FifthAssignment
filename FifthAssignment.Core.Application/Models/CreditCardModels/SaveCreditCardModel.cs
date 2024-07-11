
namespace FifthAssignment.Core.Application.Models.CreditCardModels
{
	public class SaveCreditCardModel
	{
		public double Amount { get; set; }
		public string IdentifierNumber { get; set; }
		public int CreditLimit { get; set; }
		public string UserId { get; set; }
		public string CVV { get; set; }
	}
}
