
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class ExpressPaymentRepository : BasePaymentRepository<ExpressPayment>, IExpressPaymentRepository
	{
		private readonly fifthAssignmentContext _context;

		public ExpressPaymentRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}
	}
}
