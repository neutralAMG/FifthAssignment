

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Repositories
{
	public interface IBankAccountRepository : IBaseProductRepository<BankAccount>
	{
		Task<BankAccount> GetBeneficiaryMainBankAccountAsync(string Id);
		Task<BankAccount> GetByNumberIdentifierAsync(string Id);
	}
}
