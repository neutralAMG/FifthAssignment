using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Core;
using FifthAssignment.Infraestructure.Persistence.Context;


namespace FifthAssignment.Infraestructure.Persistence.Repositories
{
	public class HomeRepository : IHomeRepository
	{
		private readonly fifthAssignmentContext _context;

		public HomeRepository(fifthAssignmentContext context)
        {
			_context = context;
		}
        public async Task<HomeInformation> GetHomeInformationAsync()
		{
			HomeInformation homeInformation = new();

			homeInformation.AmountOfTransactionAllTime = _context.Transactions.Count();
			homeInformation.AmountOfTransactionToday = _context.Transactions.Where(t => t.DateCreated.Date == DateTime.UtcNow.Date).Count();
			
			homeInformation.AmountOfPaymentsAllTime = _context.Transactions.Where(t => t.TransactionTypeId < 5 && t.TransactionTypeId > 0).Count();
			homeInformation.AmountOfPaymentsToday = _context.Transactions.Where(t => t.TransactionTypeId < 5 && t.TransactionTypeId > 0 && t.DateCreated.Date == DateTime.UtcNow.Date).Count();
			var amountCreditCad = _context.CreditCards.Where(c => c.IsDelete == false).Count();
			var amountBanckAcount = _context.BankAccounts.Where(b => b.IsDelete == false).Count();
			var amountLoan = _context.Loans.Where(l => l.IsDelete == false).Count();
		    homeInformation.AmountOfProducts = amountCreditCad + amountBanckAcount + amountLoan;

			return homeInformation;
		}

		
	}
}
