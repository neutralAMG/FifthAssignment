using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class LoanPayment : BaseDateCreatedEntity<Guid>
    {
		public LoanPayment()
		{
			Id = Guid.NewGuid();
		}
		public double Amount { get; set; }
		public Guid UserBankAccountId { get; set; }
        public Guid UserLoanId { get; set; }
		[ForeignKey("UserBankAccountId")]
		public BankAccount UserBankAccount { get; set; }
		[ForeignKey("UserLoanId")]
		public Loan UserLoan { get; set; }
    }
}
