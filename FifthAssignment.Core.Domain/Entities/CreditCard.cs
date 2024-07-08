
using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Domain.Entities
{
	public class CreditCard : BaseBankProductTypeEntity<Guid>
	{
		public string UserId { get; set; }
	  //	public User user { get; set; }
	}
}
