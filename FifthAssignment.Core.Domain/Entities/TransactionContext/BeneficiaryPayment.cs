using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class BeneficiaryPayment : BaseDateCreatedEntity<Guid>
    {
		public BeneficiaryPayment()
		{
			Id = Guid.NewGuid();
		}
		[Column(TypeName = "Decimal(18,2)")]
		public decimal Amount { get; set; }
		public Guid UserBankAccountId { get; set; }
        public Guid BeneficiaryBankAccountId { get; set; }
		[ForeignKey("UserBankAccountId")]
		public BankAccount UserBankAccount { get; set; }
		[ForeignKey("BeneficiaryBankAccountId")]
		public BankAccount UserBeneficiaryBankAccount { get; set; }
    }
}
