using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class Beneficiary : BaseEntity<Guid>
    {
		public Beneficiary()
		{
			Id = Guid.NewGuid();
			
		}
		public string UserId { get; set; }
        public string UserBeneficiaryId { get; set; }
		public Guid  UserBeneficiaryBankAccountId { get; set; }
		[ForeignKey("UserBeneficiaryBankAccountId")]
		public BankAccount UserBeneficiaryBankAccount { get; set; }
		public IList<BeneficiaryPayment> BeneficiaryPayments { get; set; }

	}
}
