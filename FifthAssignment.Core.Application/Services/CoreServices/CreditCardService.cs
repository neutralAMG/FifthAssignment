using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Utils.GenerateProductCodeString;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Core.Application.Services.CoreServices
{
    public class CreditCardService : BaseProductService<CreditCardModel, SaveCreditCardModel, CreditCard>, ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
		private readonly ICodeGenerator _codeGenerator;
		private readonly AuthenticationResponse _currentUser;
        private readonly SessionKeys _sessionkeys;

        public CreditCardService(ICreditCardRepository creditCardRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys, ICodeGenerator codeGenerator) : base(creditCardRepository, mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
            _httpContext = httpContext;
			_codeGenerator = codeGenerator;
			_sessionkeys = sessionKeys.Value;
            _currentUser = _httpContext.HttpContext.Session.Get<AuthenticationResponse>(_sessionkeys.user);
        }

        public async Task<Result<List<CreditCardModel>>> GetAllWithUserIdAsync()
        {
            Result<List<CreditCardModel>> result = new();
            try
            {
                List<CreditCard> bankAccounts = await _creditCardRepository.GetAllAsync(u => u.UserId == _currentUser.Id);

                result.Data = _mapper.Map<List<CreditCardModel>>(bankAccounts);

                result.Message = "BankAccounts get was a success";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error getting the BankAccounts";
                return result;
            }
        }

        public async Task<Result<CreditCardModel>> GetByNumberIdentifierAsync(string id)
        {
            Result<CreditCardModel> result = new();
            try
            {
                CreditCard creditCardGetted = await _creditCardRepository.GetByNumberIdentifierAsync(b => b.IdentifierNumber == id);

                result.Data = _mapper.Map<CreditCardModel>(creditCardGetted);

                result.Message = "CreditCard get was a success";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Criitical error getting the CreditCard";
                return result;
            }
        }

        public override async Task<Result<SaveCreditCardModel>> SaveAsync(SaveCreditCardModel entity)
        {
            entity.IdentifierNumber = _codeGenerator.GenerateNumberIdentifierCode();
            entity.CVV = _codeGenerator.GenerateCreditCardCVVCode();
            entity.UserId = _currentUser.Id;
            return await base.SaveAsync(entity);
        }
    }
}
