using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities.PersistanceContext
{
    public class BankAccount : BaseBankProductTypeEntity<Guid>
    {
        //	public User user {  get; set; }  
        public bool IsMain {  get; set; }
    }
}
