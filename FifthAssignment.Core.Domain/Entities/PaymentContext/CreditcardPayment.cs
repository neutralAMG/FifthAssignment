using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class CreditcardPayment : BaseEntity<Guid>
    {
		public double Amount { get; set; }
		public Guid UserBankAccountId { get; set; }
        public Guid UserCreditCardId { get; set; }
        public BankAccount UserBackAccoount { get; set; }
        public CreditCard UserCreditCard { get; set; }


    }
}
