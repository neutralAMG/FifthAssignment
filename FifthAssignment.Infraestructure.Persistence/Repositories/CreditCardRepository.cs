
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

		public override async Task<IList<CreditCard>> GetAllAsync()
		{
			return await _context.CreditCards.ToListAsync();
		}

		public override async Task<CreditCard> GetByIdAsync(Guid id)
		{
			return await _context.CreditCards.FindAsync(id);
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
			return await base.DeleteAsync(entity);
		}
	}
}
