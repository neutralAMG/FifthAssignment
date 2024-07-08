using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class CreditCard : BaseBankProductTypeEntity<Guid>
    {
        public string CardId { get; set; }
        public string CVV { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UserId { get; set; }

        //	public User user { get; set; }
    }
}
