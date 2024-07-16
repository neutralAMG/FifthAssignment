


using FifthAssignment.Core.Application.Core;
using FifthAssignment.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Core
{
	public class BaseRepository<TEntity> : IBaseProductRepository<TEntity> where TEntity : class
	{
		private readonly fifthAssignmentContext _context;
		private readonly DbSet<TEntity> _entities;
		public BaseRepository(fifthAssignmentContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}

		public virtual async Task<bool> Exits(Func<TEntity, bool> filter)
		{
			return await Task.FromResult(_entities.Any(filter));
		}

		public virtual async Task<List<TEntity>> GetAllAsync()
		{
			return await _entities.ToListAsync();
		}
        public async Task<List<TEntity>> GetAllAsync(Func<TEntity, bool> filter)
		{
			return await Task.FromResult( _entities.Where(filter).ToList());
		}
		public virtual async Task<TEntity> GetByIdAsync(Guid id)
		{
			return await _entities.FindAsync(id);
		}
	 //    public async Task<TEntity> GetByNumberIdentifierAsync(Func<TEntity, bool> filter)
		//{
		//	return await Task.FromResult( _entities.Where(filter).FirstOrDefault());
		//}
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

		public virtual async Task<bool> UpdateAsync(TEntity entity)
		{
			try
			{
				_entities.Attach(entity);
				_entities.Entry(entity).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{

				return false;
			}

		}
		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			try
			{
                _entities.Attach(entity);
                _entities.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
			}
			catch { 
			return false;
			}
		}

	
	}
}
