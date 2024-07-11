
using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
	public class TransactionDetail : BaseEntity<Guid>
	{
		public Guid PaymentId { get; set; }
	
		public int TransactionTypeId { get; set; }
		public Guid SpecificPaymentDetailId { get; set; }
		public Transaction Payment { get; set; }
		public TransactionType PaymentType { get; set; }
	}
}
