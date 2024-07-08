using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PaymentContext
{
    public class PaymentType : BaseEntity<int>
    {
        public string Name { get; set; }

        public IList<Payment> Payments { get; set; }
    }
}
