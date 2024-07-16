

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Utils.GenerateProductCodeString;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Core.Application.Services.CoreServices
{
    public class LoanService : BaseProductService<LoanModel, SaveLoanModel, Loan>, ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
		private readonly ICodeGenerator _codeGenerator;
		private readonly AuthenticationResponse _currentUser;
        private readonly SessionKeys _sessionkeys;

        public LoanService(ILoanRepository loanRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys, ICodeGenerator codeGenerator) : base(loanRepository, mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _httpContext = httpContext;
			_codeGenerator = codeGenerator;
			_sessionkeys = sessionKeys.Value;
            _currentUser = _httpContext.HttpContext.Session.Get<AuthenticationResponse>(_sessionkeys.user);
        }

        public async Task<Result<List<LoanModel>>> GetAllWithCurrentUserIdAsync()
        {
            Result<List<LoanModel>> result = new();
            try
            {
                List<Loan> bankAccounts = await _loanRepository.GetAllAsync(u => u.UserId == _currentUser.Id);

                result.Data = _mapper.Map<List<LoanModel>>(bankAccounts);

                result.Message = "Loans get was a success";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error getting the Loans";
                return result;
            }
        }
		public async Task<Result<List<LoanModel>>> GetAllWithAnSpecificUserIdAsync(string Id)
		{
			Result<List<LoanModel>> result = new();
			try
			{
				List<Loan> bankAccounts = await _loanRepository.GetAllAsync(u => u.UserId == Id);

				result.Data = _mapper.Map<List<LoanModel>>(bankAccounts);

				result.Message = "Loans get was a success";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error getting the Loans";
				return result;
			}
		}
		//public async Task<Result<LoanModel>> GetByNumberIdentifierAsync(string id)
		//{
		//    Result<LoanModel> result = new();
		//    try
		//    {
		//        Loan LoanGetted = await _loanRepository.GetByNumberIdentifierAsync(b => b.IdentifierNumber == id);

		//        result.Data = _mapper.Map<LoanModel>(LoanGetted);

		//        result.Message = "Loan get was a success";
		//        return result;
		//    }
		//    catch
		//    {
		//        result.IsSuccess = false;
		//        result.Message = "Criitical error getting the Loan";
		//        return result;
		//    }
		//}

		public override async Task<Result<SaveLoanModel>> SaveAsync(SaveLoanModel entity)
        {
            entity.IdentifierNumber = _codeGenerator.GenerateNumberIdentifierCode();
            return await base.SaveAsync(entity);
        }

		public override async Task<Result<bool>> DeleteAsync(Guid id)
		{
			Result<bool> result = new();
			var loan = await _loanRepository.GetByIdAsync(id);
			if (loan.Amount > 0)
			{
				result.IsSuccess = false;
				result.Message = "Cant delete a loan that is still owned";
				result.Data = false;
				return result;
			}
			return await base.DeleteAsync(id);
		}
	}
}
