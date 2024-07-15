using FifthAssignment.Core.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Transaction : BaseDateCreatedEntity<Guid>
    {
		public Transaction()
		{
			Id = Guid.NewGuid();
		}
		[Column(TypeName = "Decimal(18,2)")]
		public decimal Amount { get; set; }
		public int TransactionTypeId { get; set; }
		public Guid? TransactionDetailId { get; set; }
	
		public TransactionDetail? TransactionDetail { get; set; }
		[ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }


    }


}
