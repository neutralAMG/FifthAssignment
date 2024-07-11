using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts.Core
{
    public interface ICreditCardService : IBaseProductService<CreditCardModel, SaveCreditCardModel, CreditCard>, IGetWithUserId<CreditCardModel>
    {
        Task<Result<CreditCardModel>> GetByNumberIdentifierAsync(string id);
    }
}
