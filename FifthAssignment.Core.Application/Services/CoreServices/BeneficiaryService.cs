using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
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
    public class BeneficiaryService : BaseProductService<BeneficiaryModel, SaveBeneficiaryModel, Beneficiary>, IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
		private readonly IUserService _userService;
		private readonly AuthenticationResponse _currentUser;
        private readonly SessionKeys _sessionkeys;

        public BeneficiaryService(IBeneficiaryRepository beneficiaryRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys, IUserService userService) : base(beneficiaryRepository, mapper)
        {
            _beneficiaryRepository = beneficiaryRepository;
            _mapper = mapper;
            _httpContext = httpContext;
			_userService = userService;
			_sessionkeys = sessionKeys.Value;
            _currentUser = _httpContext.HttpContext.Session.Get<AuthenticationResponse>(_sessionkeys.user);
        }

        public async Task<Result<List<BeneficiaryModel>>> GetAllWithCurrentUserIdAsync()
        {
            Result<List<BeneficiaryModel>> result = new();
            try
            {
                List<Beneficiary> beneficiaries = await _beneficiaryRepository.GetAllAsync(u => u.UserId == _currentUser.Id);

                result.Data = _mapper.Map<List<BeneficiaryModel>>(beneficiaries);

                result.Data.ForEach(b => b.UserBeneficiary = _userService.GetUserBeneficiarieAsync(b.UserBeneficiaryBankAccount.UserId).Result.Data);

              
                result.Message = "Beneficiaries get was a success";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error getting the Beneficiaries";
                return result;
            }
        }
		public async Task<Result<List<BeneficiaryModel>>> GetAllWithAnSpecificUserIdAsync(string Id)
		{
			Result<List<BeneficiaryModel>> result = new();
			try
			{
				List<Beneficiary> bankAccounts = await _beneficiaryRepository.GetAllAsync(u => u.UserId == Id);

				result.Data = _mapper.Map<List<BeneficiaryModel>>(bankAccounts);

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
		public override async Task<Result<SaveBeneficiaryModel>> SaveAsync(SaveBeneficiaryModel entity)
        {
            entity.UserId = _currentUser.Id;
            return await base.SaveAsync(entity);
        }
    }
}
