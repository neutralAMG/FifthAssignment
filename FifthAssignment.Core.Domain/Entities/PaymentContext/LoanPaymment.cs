using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class LoanPayment : BaseEntity<Guid>
    {
        public Guid UserBankAccountId { get; set; }
        public Guid UserLoanId { get; set; }
        public Guid PaymentId { get; set; }
        public BankAccount UserBackAccoount { get; set; }
        public Loan UserLoan { get; set; }
        public Payment Payment { get; set; }
    }
}
