

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Payments
{
	public interface IBeneficiaryPaymentRepository : IBasePaymentRepository<BeneficiaryPayment>
	{
	}
}
