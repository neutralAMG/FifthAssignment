

using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

namespace FifthAssignment.Infraestructure.Payments.Repositories
{
	internal class BeneficiaryPaymentRepository : BasePaymentRepository<BeneficiaryPayment>, IBeneficiaryPaymentRepository
	{
		private readonly PaymentContext _context;

		public BeneficiaryPaymentRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}
	}
}
