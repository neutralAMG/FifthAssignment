﻿


using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Core
{
	public class BasePaymentRepository<TEntity> : IBasePaymentRepository<TEntity> 
		where TEntity : class
	{
		private readonly PaymentContext _context;
		private readonly DbSet<TEntity> _entities;
		public BasePaymentRepository(PaymentContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}
		public virtual async Task<IList<TEntity>> GetAllAsync()
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