using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class CreditcardPayment : BaseDateCreatedEntity<Guid>
    {
		public CreditcardPayment()
		{
			Id = Guid.NewGuid();
		}
		public double Amount { get; set; }
		public Guid UserBankAccountId { get; set; }
        public Guid UserCreditCardId { get; set; }
        public BankAccount UserBankAccount { get; set; }
        public CreditCard UserCreditCard { get; set; }


    }
}
