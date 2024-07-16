using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class Loan : BaseBankProductTypeEntity<Guid>
    {
		public Loan()
		{
			Id = Guid.NewGuid();
		}
		// public User user { get; set; }
		public IList<LoanPayment>? LoansPayments { get; set; }
	}
}
