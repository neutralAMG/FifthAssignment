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
			
			homeInformation.AmountOfPaymentsAllTime = _context.Transactions.Where(t => t.TransactionTypeId < 4 && t.TransactionTypeId > 0).Count();
			homeInformation.AmountOfPaymentsAllTime = _context.Transactions.Where(t => t.TransactionTypeId < 4 && t.TransactionTypeId > 0 && t.DateCreated.Date == DateTime.UtcNow.Date).Count();
			var amountCreditCad = _context.CreditCards.Count();
			var amountBanckAcount = _context.BankAccounts.Count();
			var amountLoan = _context.Loans.Count();
		    homeInformation.AmountOfProducts = amountCreditCad + amountBanckAcount + amountLoan;

			return homeInformation;
		}

		
	}
}
