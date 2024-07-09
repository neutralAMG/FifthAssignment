

namespace FifthAssignment.Core.Application.Core
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(Guid id);
		Task<TEntity> SaveAsync(TEntity entity);
	}
	public interface IBaseProductRepository<TEntity> : IBaseRepository<TEntity> 
		where TEntity : class
	{
		Task<bool> Exits(Func<TEntity, bool> filter);
		Task<List<TEntity>> GetAllAsync(Func<TEntity, bool> filter);
		Task<bool> UpdateAsync(TEntity entity);
		Task<bool> DeleteAsync(TEntity entity);
	}
}
