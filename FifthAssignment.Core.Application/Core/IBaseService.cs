

namespace FifthAssignment.Core.Application.Core
{
	public interface IBasePaymentService<TEntity>
		where TEntity : class
	{
		Task<Result<List<GetBasePaymentDto>>> GetAllAsync();
		Task<Result<GetBasePaymentDto>> GetByIdAsync(Guid id);
	    Task<Result<SaveBasePaymentDto>> SaveAsync(SaveBasePaymentDto entity);

	}

	public interface IBaseProductService<TGetModel, TSaveModel, TEntity>
		where TGetModel : class
		where TSaveModel : class
		where TEntity : class
	{
		Task<Result<List<TGetModel>>> GetAllAsync();
		Task<Result<TGetModel>> GetByIdAsync(Guid id);
		Task<Result<TSaveModel>> SaveAsync(TSaveModel entity);
		Task<Result<bool>> UpdateAsync(TSaveModel entity);
		Task<Result<bool>> DeleteAsync(Guid id);
	}
}
