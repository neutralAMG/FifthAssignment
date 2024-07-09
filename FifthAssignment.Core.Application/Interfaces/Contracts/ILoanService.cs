
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface ILoanService : IBaseProductService<LoanModel, SaveLoanModel, Loan>, IGetWithUserId<LoanModel>
	{
	}
}
