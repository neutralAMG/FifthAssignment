


using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Core
{
	public class BasePaymentRepository<TEntity> : IBaseRepository<TEntity> 
		where TEntity : class
	{
		private readonly fifthAssignmentContext _context;
		private readonly DbSet<TEntity> _entities;
		public BasePaymentRepository(fifthAssignmentContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}
		public virtual async Task<List<TEntity>> GetAllAsync()
		{
			return await _entities.ToListAsync();
		}

		public virtual async Task<TEntity> GetByIdAsync(Guid id)
		{
			return await _entities.FindAsync(id);
		}

		public virtual async Task<TEntity> SaveAsync(TEntity entity)
		{
			try
			{
				_entities.Add(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch
			{

				throw;
			}
		}

	}
}
