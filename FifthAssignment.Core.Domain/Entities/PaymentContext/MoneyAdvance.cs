

using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
	public class MoneyAdvance
	{
		public double Amount { get; set; }
		public Guid UserCreditCardId { get; set; }
		public Guid UserBankAccountId { get; set; }
		public CreditCard UserCreditCard { get; set; }
		public BankAccount UserBackAccoount { get; set; }
	}
}
