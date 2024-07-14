

using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Models.BeneficiaryModels
{
	public class SaveBeneficiaryModel
	{
		public string UserId { get; set; }
		public string UserBeneficiaryId { get; set; }
		public Guid UserBeneficiaryBankAccountId { get; set; }
	}
}
