using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class CreditcardPayment : BaseDateCreatedEntity<Guid>
    {
		public CreditcardPayment()
		{
			Id = Guid.NewGuid();
		}
		[Column(TypeName = "Decimal(18,2)")]
		public decimal Amount { get; set; }
		public Guid? UserBankAccountId { get; set; }
        public Guid? UserCreditCardId { get; set; }
        public BankAccount? UserBankAccount { get; set; }
        public CreditCard? UserCreditCard { get; set; }


    }
}
