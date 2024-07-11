using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class LoanPayment : BaseDateCreatedEntity<Guid>
    {
		public double Amount { get; set; }
		public Guid UserBankAccountId { get; set; }
        public Guid UserLoanId { get; set; }
        public BankAccount UserBackAccoount { get; set; }
        public Loan UserLoan { get; set; }
    }
}
