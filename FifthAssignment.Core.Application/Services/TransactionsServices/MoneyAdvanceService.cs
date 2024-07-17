

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Services.CoreServices;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Services.TransactionsServices
{
    public class MoneyAdvanceService : BasePaymentService<MoneyAdvance>, IMoneyAdvanceService
	{
		private readonly IMoneyAdvanceRepository _moneyAdvanceRepository;
		private readonly IMapper _mapper;
		private readonly IBankAccountService _bankAccountService;
		private readonly ICreditCardService _creditCardService;
		private readonly ITransactionService _transactionService;

		public MoneyAdvanceService(IMoneyAdvanceRepository moneyAdvanceRepository, IMapper mapper, IBankAccountService bankAccountService, ICreditCardService creditCardService, ITransactionService transactionService) : base(moneyAdvanceRepository, mapper)
		{
			_moneyAdvanceRepository = moneyAdvanceRepository;
			_mapper = mapper;
			_bankAccountService = bankAccountService;
			_creditCardService = creditCardService;
			_transactionService = transactionService;
		}

		public async Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto paymentDto)
		{
			Result<SaveBasePaymentDto> result = new();
			try
			{
				Result<CreditCardModel> Emisor = await _creditCardService.GetByIdAsync(paymentDto.Emisor);

				Result<BankAccountModel> Receiver = await _bankAccountService.GetByIdAsync(paymentDto.Receiver);

				Receiver.Data.Amount += paymentDto.Amount;
				Emisor.Data.Amount += paymentDto.Amount + 6.25m;
			
				await _creditCardService.UpdateAsync(_mapper.Map< SaveCreditCardModel>(Emisor.Data));

				await _bankAccountService.UpdateAsync(_mapper.Map<SaveBankAccountModel>(Receiver.Data));

				result = await SaveAsync(paymentDto);

				result.Message = "Payment successfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical Error while processing the previous payment";
				return result;
			}
		}

		public async Task<Result<bool>> ValidateTransaction(SaveBasePaymentDto paymentDto)
		{
			Result<bool> result = new();
			try
			{
				Result<CreditCardModel> Emisor = await _creditCardService.GetByIdAsync(paymentDto.Emisor);

				Result<BankAccountModel> Receiver = await _bankAccountService.GetByIdAsync(paymentDto.Receiver);


			
				if (Emisor.Data.Amount  > Emisor.Data.CreditLimit)
				{
					result.IsSuccess = false;
					result.Message = $"The amount that you what supases your credit card's limit remember that it is: {Emisor.Data.CreditLimit}";
					return result;
				}
				result.Message = "Money advance is authorized";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error validating the transaction";
				return result;
			}
		}

		public override async Task<Result<SaveBasePaymentDto>> SaveAsync(SaveBasePaymentDto entity)
		{
			var result = await base.SaveAsync(entity);

			if (result.IsSuccess)
			{
				await _transactionService.SaveAsync(new SavePaymentDto
				{
					Amount = entity.Amount,
					specificPaymentTosaveId = result.Data.Id,
					TransactionTypeId = entity.TransactionType,
				});
			}
			return result;
		}
	}
}
