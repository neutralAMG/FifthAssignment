
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IBankAccountService : IBaseProductService<BankAccountModel, SaveBankAccountModel, BankAccount>, IGetWithUserId<BankAccountModel>
	{
		Task<Result<BankAccountModel>> GetByNumberIdentifierAsync(string id);
	}
}
