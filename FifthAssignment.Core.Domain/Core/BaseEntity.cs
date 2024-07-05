

namespace FifthAssignment.Core.Domain.Core
{
	public class BaseEntity<TId>
	{
		public TId Id { get; set; }
	}

	public class BaseAcountTypeEntity<TId> : BaseEntity<TId>
	{
	public string BankAccountNumber { get; set; }
	}

}
