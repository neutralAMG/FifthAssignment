using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class PaymentRepository : IPaymentRepository
	{
		public Task<IList<Payment>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IList<Payment>> GetAllTodayPaymentsAsync()
		{
			throw new NotImplementedException();
		}
	}
}
