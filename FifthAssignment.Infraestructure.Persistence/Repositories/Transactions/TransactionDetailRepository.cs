using FifthAssignment.Core.Application.Interfaces.Transactions;
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class TransactionDetailRepository : BasePaymentRepository<TransactionDetail>, ITransactionDetailRepository
	{
		private readonly fifthAssignmentContext _context;

		public TransactionDetailRepository(fifthAssignmentContext context) : base(context)
		{
			_context = context;
		}
	}
}
