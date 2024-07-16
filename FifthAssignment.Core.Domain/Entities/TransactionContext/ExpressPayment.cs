using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;


namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class ExpressPayment : BaseDateCreatedEntity<Guid>
    {
		public ExpressPayment()
		{
			Id = Guid.NewGuid();
		}
		[Column(TypeName = "Decimal(18,2)")]
		public decimal Amount { get; set; }
		public Guid? BankAccountFromId { get; set; }
        public Guid? BankAccountToId { get; set; }
		[ForeignKey("BankAccountFromId")]
		public BankAccount? BankAccountFrom { get; set; }
		[ForeignKey("BankAccountToId")]
		public BankAccount? BankAccountTo { get; set; }

    }
}
