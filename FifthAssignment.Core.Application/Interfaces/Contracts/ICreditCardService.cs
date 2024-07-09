

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface ICreditCardService : IBaseProductService<CreditCardModel, SaveCreditCardModel, CreditCard>, IGetWithUserId<CreditCardModel>	
	{
	}
}
