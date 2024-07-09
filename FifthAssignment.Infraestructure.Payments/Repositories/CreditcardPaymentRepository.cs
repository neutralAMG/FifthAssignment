

using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	public class CreditcardPaymentRepository : BasePaymentRepository<CreditcardPayment>, ICreditcardPaymentRepository
	{
		private readonly PaymentContext _context;

		public CreditcardPaymentRepository(PaymentContext context) : base(context)
		{
		    _context = context;
		}
	}
}
