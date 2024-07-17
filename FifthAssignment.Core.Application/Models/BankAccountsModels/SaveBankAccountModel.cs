

using System.ComponentModel.DataAnnotations;

namespace FifthAssignment.Core.Application.Models.BankAccountsModels
{
	public class SaveBankAccountModel
	{
		public Guid Id { get; set; }
        [Required(ErrorMessage = "Amount is a requiered fild")]
        public decimal Amount { get; set; }
		public string? IdentifierNumber { get; set; }
		public string? UserId { get; set; }
		public bool IsMain { get; set; }

	}
}
