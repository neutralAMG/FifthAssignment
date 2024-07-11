

namespace FifthAssignment.Core.Application.Dtos.Payments
{
	public record GetPaymentDto
	{
	}
	public record SavePaymentDto
	{
		public double Amount { get; set; }
		public int PaymentTypeId { get; set; }
		public Guid? ExpressPaymentId { get; set; }
		public Guid? BeneficiaryPaymentId { get; set; }
		public Guid? CreditcardPaymentId { get; set; }
		public Guid? LoanPaymentId { get; set; }
	}
}
