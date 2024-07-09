﻿using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Core
{
	public interface IBasePaymentRepository<TEntity> 
		where TEntity : class
	{
		Task<IList<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(Guid id);
		Task<TEntity> SaveAsync(TEntity entity);
	}
}