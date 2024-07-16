
using FifthAssignment.Core.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
	public class TransactionDetail : BaseEntity<Guid>
	{
		public TransactionDetail()
		{
			Id = Guid.NewGuid();
		}
		public Guid? TransactionIdId { get; set; }
	
		public int TransactionTypeId { get; set; }
		public Guid? SpecificTransactionDetailId { get; set; }
		[ForeignKey("TransactionIdId")]
		public Transaction Transaction { get; set; }
		[ForeignKey("TransactionTypeId")]
		public TransactionType TransactionType { get; set; }
	}
}
