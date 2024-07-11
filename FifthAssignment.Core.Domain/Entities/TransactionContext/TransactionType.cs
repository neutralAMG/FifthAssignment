using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class TransactionType : BaseEntity<int>
    {
        public string Name { get; set; }

        public IList<Transaction> Transactions { get; set; }
        public IList<TransactionDetail> TransactionDetails { get; set; }
    }
}
