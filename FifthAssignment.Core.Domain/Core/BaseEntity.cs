

namespace FifthAssignment.Core.Domain.Core
{
	public class BaseEntity<TId>
	{
		public TId Id { get; set; }
	}

	public class BaseBankProductTypeEntity<TId> : BaseEntity<TId>
	{
		public string UserId { get; set; }
		public double Amount { get; set; }
		public string IdentifierNumber { get; set; }

		public DateTime DateCreated = DateTime.Now;
	}

	public class BaseDateCreatedEntity<TId> : BaseEntity<TId>
	{
		public DateTime DateCreated = DateTime.Now;
	}

}
