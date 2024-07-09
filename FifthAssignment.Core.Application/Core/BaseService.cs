


using AutoMapper;

namespace FifthAssignment.Core.Application.Core
{
	public class BaseService<TGetModel, TSaveModel, TEntity> : IBaseService<TGetModel, TSaveModel, TEntity>
		where TGetModel : class
		where TSaveModel : class
		where TEntity : class
	{
		private readonly IBaseRepository<TEntity> _baseRepository;
		private readonly IMapper _mapper;

		public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
			_baseRepository = baseRepository;
			_mapper = mapper;
		}
        public virtual async Task<Result<List<TGetModel>>> GetAllAsync()
		{
			Result<List<TGetModel>> result = new();
			try
			{
				List<TEntity> entitiesGetted = await _baseRepository.GetAllAsync();

				result.Data = _mapper.Map<List<TGetModel>>(entitiesGetted);

				result.Message = "Entities get was a success";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error getting the entities";
				return result;
			}
		}

		public virtual async Task<Result<TGetModel>> GetByIdAsync(Guid id)
		{
			Result<TGetModel> result = new();
			try
			{
				TEntity entityGetted = await _baseRepository.GetByIdAsync(id);

				result.Data = _mapper.Map<TGetModel>(entityGetted);

				result.Message = "Entity get was a success";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error getting the entity";
				return result;
			}
		}

		public virtual async Task<Result<TSaveModel>> SaveAsync(TSaveModel entity)
		{
			Result<TSaveModel> result = new();
			try
			{
				TEntity entityToBeSave = _mapper.Map<TEntity>(entity);

				TEntity entitySaved = await _baseRepository.SaveAsync(entityToBeSave);

				if (entitySaved == null) {
					result.IsSuccess = false;
					result.Message = "Error saving the entity";
					return result;
				}

				result.Data = _mapper.Map<TSaveModel>(entitySaved);

				result.Message = "Entity was saved succesfuly";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error saving the entity";
				return result;
			}
		}
	}



	public class BaseProductService<TGetModel, TSaveModel, TEntity> : BaseService<TGetModel, TSaveModel, TEntity>, IBaseProductService<TGetModel, TSaveModel, TEntity>
	where TGetModel : class
	where TSaveModel : class
	where TEntity : class
	{
		private readonly IBaseProductRepository<TEntity> _baseProductRepository;
		private readonly IMapper _mapper;

		public BaseProductService(IBaseProductRepository<TEntity> baseProductRepository, IMapper mapper) : base(baseProductRepository, mapper)
		{
			_baseProductRepository = baseProductRepository;
			_mapper = mapper;
		}

		public async Task<Result<List<TGetModel>>> GetAllAsync(string id)
		{
			Result<List<TGetModel>> result = new();
			try
			{
				List<TEntity> entityGetted = await _baseProductRepository.GetAllAsync();

				result.Data = _mapper.Map<List<TGetModel>>(entityGetted);

				result.Message = "Entity get was a success";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error getting the entity";
				return result;
			}
		}

		public virtual async Task<Result<bool>> UpdateAsync(TSaveModel entity)
		{
			Result<bool> result = new();
			try
			{
				TEntity entityToBeUpdate = _mapper.Map<TEntity>(entity);

				bool updateOperationIsSuccess = await _baseProductRepository.UpdateAsync(entityToBeUpdate);

				if (updateOperationIsSuccess == false)
				{
					result.IsSuccess = false;
					result.Message = "Error saving the entity";
					return result;
				}

				result.Data = updateOperationIsSuccess;

				result.Message = "Entity was updated succesfuly";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error updating the entity";
				return result;
			}
		}
		public virtual async Task<Result<bool>> DeleteAsync(Guid id)
		{
			Result<bool> result = new();
			try
			{
				TEntity entitygettedToBeDelete = await _baseProductRepository.GetByIdAsync(id);

				TEntity entityToBeDelete = _mapper.Map<TEntity>(entitygettedToBeDelete);

				bool deleteOperationIsSuccess = await _baseProductRepository.UpdateAsync(entityToBeDelete);

				if (!deleteOperationIsSuccess)
				{
					result.IsSuccess = false;
					result.Message = "Error deleting the entity";
					return result;
				}

				result.Data = deleteOperationIsSuccess;

				result.Message = "Entity was deleted succesfuly";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error deleting the entity";
				return result;
			}
		}

	}
}
