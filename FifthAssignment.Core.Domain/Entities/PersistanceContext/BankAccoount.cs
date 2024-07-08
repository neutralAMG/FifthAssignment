using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class BankAccount : BaseBankProductTypeEntity<Guid>
    {
        public string BankAccountNumber { get; set; }
        public string UserId { get; set; }
        //	public User user {  get; set; }  
    }
}
