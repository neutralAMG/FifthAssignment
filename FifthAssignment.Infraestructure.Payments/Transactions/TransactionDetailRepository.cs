using FifthAssignment.Core.Application.Interfaces.Transactions;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthAssignment.Infraestructure.Transaction.Repositories
{
	public class TransactionDetailRepository : BasePaymentRepository<TransactionDetail>, ITransactionDetailRepository
	{
		private readonly PaymentContext _context;

		public TransactionDetailRepository(PaymentContext context) : base(context)
		{
			_context = context;
		}
	}
}
