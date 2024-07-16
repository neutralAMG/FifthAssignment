using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class BankAccount : BaseBankProductTypeEntity<Guid>
    {
		public BankAccount() {  
			Id = Guid.NewGuid();
			IsMain = false;
		}
        //	public User user {  get; set; }  
        public bool IsMain {  get; set; }
		public IList<Beneficiary>? Beneficiarys { get; set; }		
		public IList<BeneficiaryPayment>? BeneficiaryPayments { get; set; }
		public IList<BeneficiaryPayment>? UserPayments { get; set; }
		public IList<ExpressPayment>? ExpressPaymentsFrom { get; set; }
		public IList<ExpressPayment>? ExpressPaymentsTo { get; set; }
		public IList<CreditcardPayment>? CreditCardPayments { get; set; }
		public IList<MoneyAdvance>? MoneyAdvances { get; set; }
		public IList<Transfer>? TransfersFrom { get; set; }
		public IList<Transfer>? TransfersTo { get; set; }
		public IList<LoanPayment>? LoansPayments { get; set; }

	}
}
