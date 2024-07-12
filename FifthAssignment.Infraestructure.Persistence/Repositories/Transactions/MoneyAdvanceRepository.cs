
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class MoneyAdvanceRepository : BasePaymentRepository<MoneyAdvance>, IMoneyAdvanceRepository
	{
		private readonly fifthAssignmentContext _context;

		public MoneyAdvanceRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}
	}
}
