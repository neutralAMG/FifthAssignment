using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Payment : BaseDateCreatedEntity<Guid>
    {
        public double Amount { get; set; }
        public int PaymentTypeId { get; set; }
		public Guid? ExpressPaymentId { get; set; }
		public Guid? BeneficiaryPaymentId { get; set; }
		public Guid? CreditcardPaymentId { get; set; }
		public Guid? LoanPaymentId { get; set; }

	    public ExpressPayment? ExpressPayment { get; set; }
        public BeneficiaryPayment? BeneficiaryPayment { get; set; }
        public CreditcardPayment? CreditcardPayment { get; set; }
        public LoanPayment? LoanPayment { get; set; }
        public PaymentType? PymentType { get; set; }
    }


}
