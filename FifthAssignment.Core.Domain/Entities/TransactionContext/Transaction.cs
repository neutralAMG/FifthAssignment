using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class Transaction : BaseDateCreatedEntity<Guid>
    {
        public double Amount { get; set; }
		public int PaymentTypeId { get; set; }
		public Guid? TransactionDetailId { get; set; }
		public TransactionDetail? TransactionDetail { get; set; }
        public TransactionType TransactionType { get; set; }


    }


}
