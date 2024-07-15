
namespace FifthAssignment.Core.Application.Models.CreditCardModels
{
	public class CreditCardModel : BaseProductModel
	{
		public CreditCardModel()
		{
			Type = "Credit card";
		}
		public int CreditLimit { get; set; }
		public string CVV { get; set; }
		public DateTime ExpirationDate { get; set; }
	}
}
