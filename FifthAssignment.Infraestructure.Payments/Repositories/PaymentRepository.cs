using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class PaymentRepository : BasePaymentRepository<Payment>, IPaymentRepository
	{
		private readonly PaymentContext _context;

		public PaymentRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IList<Payment>> GetAllTodayPaymentsAsync()
		{
			return await _context.Payments.Where(p => p.DateCreated.Date == DateTime.UtcNow.Date).ToListAsync();
		}
	}
}
