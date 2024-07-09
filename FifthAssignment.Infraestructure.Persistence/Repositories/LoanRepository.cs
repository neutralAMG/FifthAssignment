

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class LoanRepository : BaseRepository<Loan>, ILoanRepository
	{
		private readonly fifthAssignmentContext _context;

		public LoanRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}
	
		public override async Task<Loan> SaveAsync(Loan entity)
		{
			return await base.SaveAsync(entity);
		}

		public virtual async Task<bool> UpdateAsync(Loan entity)
		{
			Loan LoanToUpdate = await GetByIdAsync(entity.Id);

			LoanToUpdate.Amount = entity.Amount;

			return await base.UpdateAsync(LoanToUpdate);

		}
		public override async Task<bool> DeleteAsync(Loan entity)
		{
			return await base.DeleteAsync(entity);
		}
	}
}
