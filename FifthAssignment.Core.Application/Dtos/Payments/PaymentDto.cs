

namespace FifthAssignment.Core.Application.Dtos.Payments
{
	public record GetPaymentDto
	{
	}
	public record SavePaymentDto
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public int TransactionTypeId { get; set; }
		public Guid specificPaymentTosaveId { get; set; }
		public Guid? TransactionDetailId { get; set; }
	}
}
