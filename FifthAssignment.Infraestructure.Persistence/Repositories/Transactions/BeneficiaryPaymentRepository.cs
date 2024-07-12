

using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	internal class BeneficiaryPaymentRepository : BasePaymentRepository<BeneficiaryPayment>, IBeneficiaryPaymentRepository
	{
		private readonly fifthAssignmentContext _context;

		public BeneficiaryPaymentRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<BeneficiaryPayment>> GetAllAsync()
		{
			return await base.GetAllAsync();
		}

		public override async Task<BeneficiaryPayment> GetByIdAsync(Guid id)
		{
			return await base.GetByIdAsync(id);
		}

		public override async Task<BeneficiaryPayment> SaveAsync(BeneficiaryPayment entity)
		{
			return await base.SaveAsync(entity);
		}
	}
}
