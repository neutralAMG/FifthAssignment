
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Models.BeneficiaryModels
{
	public class BeneficiaryModel
	{
		public Guid Id { get; set; }
		public string IdentifierNumber { get; set; }
		public string UserId { get; set; }
		public string UserBeneficiaryId { get; set; }
		public Guid UserBeneficiaryBankAccountId { get; set; }
		public BankAccountModel UserBeneficiaryBankAccount { get; set; }

	}
}
