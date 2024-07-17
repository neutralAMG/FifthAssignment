
using System.ComponentModel.DataAnnotations;

namespace FifthAssignment.Core.Application.Models.CreditCardModels
{
	public class SaveCreditCardModel
	{
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
		public string? IdentifierNumber { get; set; }
        [Required(ErrorMessage = "Credit limit is a requiered fild")]
        public int CreditLimit { get; set; }
		public string? UserId { get; set; }
		public string? CVV { get; set; }

		public DateTime ExpirationDate { get; set; }
	}
}
