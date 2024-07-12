
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Transaction.Repositories
{
	public class MoneyAdvanceRepository : BasePaymentRepository<MoneyAdvance>, IMoneyAdvanceRepository
	{
		private readonly PaymentContext _context;

		public MoneyAdvanceRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}
	}
}
