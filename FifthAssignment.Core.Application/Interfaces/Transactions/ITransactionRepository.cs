using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Interfaces.Payments
{
	public interface ITransactionRepository : IBaseRepository<Transaction>
	{
		Task<IList<Transaction>> GetAllTodayPaymentsAsync();
		Task<bool> UpdateAsync(Transaction transaction);
	}
}
