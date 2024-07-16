using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Utils.GenerateProductCodeString;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Core.Application.Services.CoreServices
{
	internal class BankAccountService : BaseProductService<BankAccountModel, SaveBankAccountModel, BankAccount>, IBankAccountService
	{
		private readonly IBankAccountRepository _bankAccountRepository;
		private readonly IMapper _mapper;

		private AuthenticationResponse _currentUser;
		private readonly IHttpContextAccessor _httpContext;
		private readonly ICodeGenerator _codeGenerator;
		private readonly SessionKeys _sessionkeys;

		public BankAccountService(IBankAccountRepository bankAccountRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys, ICodeGenerator codeGenerator) : base(bankAccountRepository, mapper)
		{
			_bankAccountRepository = bankAccountRepository;
			_mapper = mapper;
			_httpContext = httpContext;
			_codeGenerator = codeGenerator;
			_sessionkeys = sessionKeys.Value;
			_currentUser = new();
		}

		public async Task<Result<List<BankAccountModel>>> GetAllWithCurrentUserIdAsync()
		{
			Result<List<BankAccountModel>> result = new();
			try
			{
				_currentUser = _httpContext.HttpContext.Session.Get<AuthenticationResponse>(_sessionkeys.user);
				List<BankAccount> bankAccounts = await _bankAccountRepository.GetAllAsync(u => u.UserId == _currentUser.Id && u.IsDelete == false);

				result.Data = _mapper.Map<List<BankAccountModel>>(bankAccounts);

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
		public async Task<Result<List<BankAccountModel>>> GetAllWithAnSpecificUserIdAsync(string Id)
		{
			Result<List<BankAccountModel>> result = new();
			try
			{
				List<BankAccount> bankAccounts = await _bankAccountRepository.GetAllAsync(u => u.UserId == Id && u.IsDelete == false);

				result.Data = _mapper.Map<List<BankAccountModel>>(bankAccounts);

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
		//public async Task<Result<BankAccountModel>> GetBeneficiaryMainBankAccountAsync(string id)
		//{
		//	Result<BankAccountModel> result = new();
		//	try
		//	{

		//		BankAccount entityGetted = await _bankAccountRepository.GetBeneficiaryMainBankAccountAsync(id);

		//		result.Data = _mapper.Map<BankAccountModel>(entityGetted);

		//		result.Message = "BankAccount get was a success";
		//		return result;
		//	}
		//	catch
		//	{
		//		result.IsSuccess = false;
		//		result.Message = "Criitical error getting the BankAccount";
		//		return result;
		//	}
		//}

		public async Task<Result<BankAccountModel>> GetByNumberIdentifierAsync(string id)
		{
			Result<BankAccountModel> result = new();
			try
			{
				if (!await _bankAccountRepository.Exits(b => b.IdentifierNumber == id))
				{
					result.IsSuccess = false;
					result.Message = $"there's no banck account with this number: {id}";
					return result;
				}
				BankAccount entityGetted = await _bankAccountRepository.GetByNumberIdentifierAsync(id);

				result.Data = _mapper.Map<BankAccountModel>(entityGetted);

				result.Message = "BankAccount get was a success";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error getting the BankAccount";
				return result;
			}
		}

		public override async Task<Result<SaveBankAccountModel>> SaveAsync(SaveBankAccountModel entity)
		{
			entity.IdentifierNumber = _codeGenerator.GenerateNumberIdentifierCode();
			//	entity.UserId = _currentUser.Id;
			return await base.SaveAsync(entity);
		}

		public override async Task<Result<bool>> DeleteAsync(Guid id)
		{
			Result<bool> result = new();
			var isMain = await _bankAccountRepository.GetByIdAsync(id);
			if (isMain.IsMain)
			{
				result.IsSuccess = false;
				result.Message = "Cant delete the users main bank account";
				result.Data = false;
				return result;
			}
			return await base.DeleteAsync(id);
		}


	}
}
