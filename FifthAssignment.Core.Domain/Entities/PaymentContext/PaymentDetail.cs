
using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
	public class PaymentDetail : BaseEntity<Guid>
	{
		public Guid PaymentId { get; set; }
	
		public Guid PaymentTypeId { get; set; }
		public Guid SpecificPaymentDetailId { get; set; }
		public Payment Payment { get; set; }
		public PaymentType PaymentType { get; set; }
	}
}
