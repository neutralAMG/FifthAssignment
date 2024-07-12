using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;

using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class TransactionRepository : BasePaymentRepository<FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction>, ITransactionRepository
	{
		private readonly fifthAssignmentContext _context;

		public TransactionRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IList<FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction>> GetAllTodayPaymentsAsync()
		{
			return await _context.Transactions.Where(p => p.DateCreated.Date == DateTime.UtcNow.Date).ToListAsync();
		}

		public async Task<bool> UpdateAsync(FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction transaction)
		{
			try
			{
				var transactionToBeUpdated = await base.GetByIdAsync(transaction.Id);

				transactionToBeUpdated.TransactionDetailId = transaction.TransactionDetailId;
				_context.Transactions.Attach(transaction);
				_context.Transactions.Entry(transaction).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
