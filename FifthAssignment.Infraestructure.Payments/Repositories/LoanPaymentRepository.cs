using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;


namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class LoanPaymentRepository : BasePaymentRepository<LoanPayment>, ILoanPaymentRepository
	{
		private readonly PaymentContext _context;

		public LoanPaymentRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}
	}
}
