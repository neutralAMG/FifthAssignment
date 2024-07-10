using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class CreditCard : BaseBankProductTypeEntity<Guid>
    {
        public string CVV { get; set; }
        public DateTime ExpirationDate { get; set; }

        //	public User user { get; set; }
    }
}
