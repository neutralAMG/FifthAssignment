

using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
	public class MoneyAdvance : BaseDateCreatedEntity<Guid>
	{
		public MoneyAdvance()
		{
			Id = Guid.NewGuid();
		}
		[Column(TypeName = "Decimal(18,2)")]
		public decimal Amount { get; set; }
		public Guid UserCreditCardId { get; set; }
		public Guid UserBankAccountId { get; set; }
		[ForeignKey("UserCreditCardId")]
		public CreditCard UserCreditCard { get; set; }
		[ForeignKey("UserBankAccountId")]
		public BankAccount UserBankAccount { get; set; }
	}
}
