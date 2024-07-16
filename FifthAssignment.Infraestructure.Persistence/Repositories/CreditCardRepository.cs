
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
	{
		private readonly fifthAssignmentContext _context;

		public CreditCardRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}


        public virtual async Task<List<CreditCard>> GetAllAsync()
        {
            return await _context.CreditCards.Where(b => b.IsDelete == false).ToListAsync();
        }
        public async Task<List<CreditCard>> GetAllAsync(Func<CreditCard, bool> filter)
        {
            return await Task.FromResult(_context.CreditCards.Where(filter).ToList());
        }
        public virtual async Task<CreditCard> GetByIdAsync(Guid id)
        {
            return await _context.CreditCards.Where(b => b.IsDelete == false && b.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<CreditCard> SaveAsync(CreditCard entity)
		{
			entity.ExpirationDate = DateTime.UtcNow.AddMonths(5);
			return await base.SaveAsync(entity);
		}

		public virtual async Task<bool> UpdateAsync(CreditCard entity)
		{
			CreditCard CreaditCardToUpdate = await GetByIdAsync(entity.Id);

			CreaditCardToUpdate.Amount = entity.Amount;

			return await base.UpdateAsync(CreaditCardToUpdate);

		}
		public override async Task<bool> DeleteAsync(CreditCard entity)
		{
			if (entity.Amount > 0) return false;
            CreditCard CreditCardToUpdate = await GetByIdAsync(entity.Id);

			CreditCardToUpdate.IsDelete = true;

            return await base.DeleteAsync(CreditCardToUpdate);
		}
	}
}
