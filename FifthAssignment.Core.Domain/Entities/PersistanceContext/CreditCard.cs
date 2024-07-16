using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class CreditCard : BaseBankProductTypeEntity<Guid>
    {
		public CreditCard()
		{
			Id = Guid.NewGuid();
		}


		public string CVV { get; set; }
        public int CreditLimit { get; set; }
        public DateTime ExpirationDate { get; set; }

        //	public User user { get; set; }
        public IList<CreditcardPayment>? CreditCardPayments { get; set; }
        public IList<MoneyAdvance>? MoneyAdvances { get; set; }
    }
}
