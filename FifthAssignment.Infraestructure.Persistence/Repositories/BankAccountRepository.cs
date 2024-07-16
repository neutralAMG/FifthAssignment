

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


        public virtual async Task<List<BankAccount>> GetAllAsync()
        {
            return await _context.BankAccounts.Where(b => b.IsDelete == false).ToListAsync();
        }
        public async Task<List<BankAccount>> GetAllAsync(Func<BankAccount, bool> filter)
        {
            return await Task.FromResult(_context.BankAccounts.Where(filter).ToList());
        }
        public virtual async Task<BankAccount> GetByIdAsync(Guid id)
        {
            return await _context.BankAccounts.Where(b => b.IsDelete == false && b.Id == id).FirstOrDefaultAsync();
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

            BankAccount BankAccountToDelete = await GetByIdAsync(entity.Id);

            BankAccountToDelete.IsDelete = true;

            BankAccountToDelete.Amount = 0;

            return await base.DeleteAsync(entity);;
        }

        public async Task<BankAccount> GetBeneficiaryMainBankAccountAsync(string Id)
        {
            BankAccount beneficiaryBankAccount = await _context.BankAccounts.Where(b => b.IsMain == true && b.UserId == Id && b.IsDelete == false).FirstOrDefaultAsync();

            return beneficiaryBankAccount;
        }

		public async Task<BankAccount> GetByNumberIdentifierAsync(string Id)
		{
            return await _context.BankAccounts.Where(b => b.IsDelete == false && b.IdentifierNumber == Id).FirstOrDefaultAsync();
		}
	}
}
