

namespace FifthAssignment.Core.Application.Core
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<bool> Exits(Func<TEntity, bool> filter);
		Task<IList<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(Guid id);
		Task<TEntity> SaveAsync(TEntity entity);
		Task<bool> UpdateAsync(TEntity entity);
		Task<bool> DeleteAsync(Guid id);
	}
}
