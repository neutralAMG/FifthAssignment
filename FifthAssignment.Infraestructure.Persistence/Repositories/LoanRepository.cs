

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
        public virtual async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.Where(b => b.IsDelete == false).ToListAsync();
        }
        public async Task<List<Loan>> GetAllAsync(Func<Loan, bool> filter)
        {
            return await Task.FromResult(_context.Loans.Where(filter).ToList());
        }
        public virtual async Task<Loan> GetByIdAsync(Guid id)
        {
            return await _context.Loans.Where(b => b.IsDelete == false && b.Id == id).FirstOrDefaultAsync();
        }


        public override async Task<Loan> SaveAsync(Loan entity)
		{
			var mainUserAcount = await _context.BankAccounts.Where(b => b.IsMain && b.UserId == entity.UserId).FirstOrDefaultAsync();

			mainUserAcount.Amount += entity.Amount;
			_context.BankAccounts.Attach(mainUserAcount);
			_context.BankAccounts.Entry(mainUserAcount).State = EntityState.Modified;

			await _context.SaveChangesAsync();

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
			if (entity.Amount > 0) return false;

            Loan LoanToDelete = await GetByIdAsync(entity.Id);

            LoanToDelete.IsDelete = true;
            return await base.DeleteAsync(LoanToDelete);
		}
	}
}
