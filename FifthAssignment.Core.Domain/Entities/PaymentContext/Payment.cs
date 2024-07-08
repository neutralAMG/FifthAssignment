using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Payment : BaseEntity<Guid>
    {
        public double Ammount;
        public int PaymentType { get; set; }
        public ExpressPayment? ExpressPayment { get; set; }
        public BeneficiaryPayment? BeneficiaryPayment { get; set; }
        public CreditcardPayment? CreditcardPayment { get; set; }
        public LoanPayment? LoanPayment { get; set; }
    }


}
