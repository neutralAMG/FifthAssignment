
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class TransferRepository : BasePaymentRepository<Transfer>, ITransferRepository
	{
		private readonly PaymentContext _context;

		public TransferRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}

		public Task<IList<Transfer>> GetAllTodayTransfersAsync()
		{
			throw new NotImplementedException();
		}
	}
}
