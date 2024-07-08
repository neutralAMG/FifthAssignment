using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;


namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class ExpressPayment : BaseEntity<Guid>
    {
        public Guid BankAccountFromId { get; set; }
        public Guid BankAccountToId { get; set; }
        public Guid PaymentId { get; set; }
        public BankAccount BackAccoountFrom { get; set; }
        public BankAccount BackAccoountTo { get; set; }
        public Payment Payment { get; set; }

    }
}
