

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;


namespace FifthAssignment.Core.Application.Interfaces.Payments
{
	public interface ITransferRepository : IBaseRepository<Transfer>
	{
		Task<IList<Transfer>> GetAllTodayTransfersAsync();
	}
}
