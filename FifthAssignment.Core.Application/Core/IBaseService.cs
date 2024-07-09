

namespace FifthAssignment.Core.Application.Core
{
	public interface IBaseService<TGetModel, TSaveModel, TEntity>
		where TGetModel : class
		where TSaveModel : class
		where TEntity : class
	{
		Task<Result<List<TGetModel>>> GetAllAsync();	
		Task<Result<TGetModel>> GetByIdAsync(Guid id);
		Task<Result<TSaveModel>> SaveAsync(TSaveModel entity);
	
	}

	public interface IBaseProductService<TGetModel, TSaveModel, TEntity> : IBaseService<TGetModel, TSaveModel, TEntity>
		where TGetModel : class
		where TSaveModel : class
		where TEntity : class
	{	
		Task<Result<List<TGetModel>>> GetAllAsync(string id);
		Task<Result<bool>> UpdateAsync(TSaveModel entity);
		Task<Result<bool>> DeleteAsync(Guid id);
	}
}
