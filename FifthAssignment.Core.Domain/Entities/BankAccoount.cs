
using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities
{
	public class BankAccoount : BaseBankProductTypeEntity<Guid>
	{
		public string UserId { get; set; }
	 //	public User user {  get; set; }  
	}
}
