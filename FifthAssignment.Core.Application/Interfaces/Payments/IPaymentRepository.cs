using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Interfaces.Payments
{
	public interface IPaymentRepository
	{
		Task<IList<Payment>> GetAllAsync();
		Task<IList<Payment>> GetAllTodayPaymentsAsync();
	}
}
