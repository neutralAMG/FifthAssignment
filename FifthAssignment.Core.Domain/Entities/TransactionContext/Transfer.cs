using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Transfer : BaseDateCreatedEntity<Guid>
    {
		public Transfer()
		{
			Id = Guid.NewGuid();
		}
		public double Amount { get; set; }
		public Guid UserAccountFromId { get; set; }
        public Guid UserAccountToId { get; set; }
		[ForeignKey("UserAccountFromId")]
		public BankAccount UserAccountFrom { get; set; }
		[ForeignKey("UserAccountToId")]
		public BankAccount UserAccountTo { get; set; }
    }
}
