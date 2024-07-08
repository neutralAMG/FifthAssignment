using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class BeneficiaryPayment : BaseEntity<Guid>
    {
        public Guid UserBankAccountId { get; set; }
        public Guid BeneficiaryBankAccountId { get; set; }
        public Guid PaymentId { get; set; }
        public BankAccount UserBackAccoount { get; set; }
        public BankAccount BeneficiaryAccoount { get; set; }
        public Payment Payment { get; set; }
    }
}
