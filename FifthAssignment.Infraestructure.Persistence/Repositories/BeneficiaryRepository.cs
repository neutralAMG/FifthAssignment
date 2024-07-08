

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class BeneficiaryRepository : BaseRepository<Beneficiary>, IBeneficiaryRepository
	{
		private readonly fifthAssignmentContext _context;

		public BeneficiaryRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<IList<Beneficiary>> GetAllAsync()
		{
			return await _context.Beneficiaries.ToListAsync();
		}

		public override async Task<Beneficiary> GetByIdAsync(Guid id)
		{
			return await _context.Beneficiaries.FindAsync(id);
		}

		public override async Task<Beneficiary> SaveAsync(Beneficiary entity)
		{
			return await base.SaveAsync(entity);
		}

		public virtual async Task<bool> UpdateAsync(Beneficiary entity)
		{
			Beneficiary beneficiaryToUpdate = await GetByIdAsync(entity.Id);

			return await base.UpdateAsync(beneficiaryToUpdate);

		}
		public override async Task<bool> DeleteAsync(Beneficiary entity)
		{
			return await base.DeleteAsync(entity);
		}
	}
}
