

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
	{
		private readonly fifthAssignmentContext _context;

		public BankAccountRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}



		public override async Task<BankAccount> SaveAsync(BankAccount entity)
		{
			return await base.SaveAsync(entity);
		}

		public virtual async Task<bool> UpdateAsync(BankAccount entity)
		{
			BankAccount bankAccountToUpdate = await GetByIdAsync(entity.Id);

			bankAccountToUpdate.Amount = entity.Amount;

			return await base.UpdateAsync(bankAccountToUpdate);

		}
		public override async Task<bool> DeleteAsync(BankAccount entity)
		{
			if (entity.IsMain == true) return false;

			BankAccount MainBankAccount = await _context.BankAccounts.Where(b => b.UserId == entity.UserId && b.IsMain == true).FirstOrDefaultAsync();

			MainBankAccount.Amount += entity.Amount;

		    await UpdateAsync(MainBankAccount);

			return await base.DeleteAsync(entity);
		}

		public async Task<BankAccount> GetBeneficiaryMainBankAccountAsync(string Id)
		{
			BankAccount beneficiaryBankAccount = await _context.BankAccounts.Where(b => b.IsMain == true && b.UserId == Id).FirstOrDefaultAsync();

			return beneficiaryBankAccount;
		}
	}
}
