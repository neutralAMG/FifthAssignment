using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;


namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class ExpressPayment : BaseDateCreatedEntity<Guid>
    {
		public double Amount { get; set; }
		public Guid BankAccountFromId { get; set; }
        public Guid BankAccountToId { get; set; }
        public BankAccount BackAccoountFrom { get; set; }
        public BankAccount BackAccoountTo { get; set; }

    }
}
