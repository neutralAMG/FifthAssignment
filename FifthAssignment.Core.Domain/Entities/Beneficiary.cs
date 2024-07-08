

using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities
{
	public class Beneficiary : BaseEntity<Guid>
	{
		public string UserId { get; set; }
		public string UserBeneficiaryId { get; set; }

	}
}
