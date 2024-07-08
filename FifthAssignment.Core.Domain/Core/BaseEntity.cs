

namespace FifthAssignment.Core.Domain.Core
{
	public class BaseEntity<TId>
	{
		public TId Id { get; set; }
	}

	public class BaseBankProductTypeEntity<TId> : BaseEntity<TId>
	{
	public string Amount { get; set; }
	}

}
