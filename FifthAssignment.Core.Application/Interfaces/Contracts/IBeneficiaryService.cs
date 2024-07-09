

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IBeneficiaryService : IBaseProductService<BeneficiaryModel, SaveBeneficiaryModel, Beneficiary>, IGetWithUserId<BeneficiaryModel>
	{
	}
}
