
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class TransferRepository : BasePaymentRepository<Transfer>, ITransferRepository
	{
		private readonly PaymentContext _context;

		public TransferRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<Transfer>> GetAllAsync()
		{
			return await base.GetAllAsync();
		}

		public override async Task<Transfer> GetByIdAsync(Guid id)
		{
			return await base.GetByIdAsync(id);
		}

		public override async Task<Transfer> SaveAsync(Transfer entity)
		{
			return await base.SaveAsync(entity);
		}
		public async Task<IList<Transfer>> GetAllTodayTransfersAsync()
		{
			return await _context.Transfers.Where(t => t.DateCreated.Date == DateTime.UtcNow.Date).ToListAsync();
		}
	}
}
