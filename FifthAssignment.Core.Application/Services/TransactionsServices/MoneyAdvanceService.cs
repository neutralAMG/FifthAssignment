﻿

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Services.CoreServices;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Services.TransactionsServices
{
    public class MoneyAdvanceService : BasePaymentService<MoneyAdvance>, IMoneyAdvaceService
	{
		private readonly IMoneyAdvanceRepository _moneyAdvanceRepository;
		private readonly IMapper _mapper;
		private readonly IBankAccountService _bankAccountService;
		private readonly ICreditCardService _creditCardService;

		public MoneyAdvanceService(IMoneyAdvanceRepository moneyAdvanceRepository, IMapper mapper, IBankAccountService bankAccountService, ICreditCardService creditCardService) : base(moneyAdvanceRepository, mapper)
		{
			_moneyAdvanceRepository = moneyAdvanceRepository;
			_mapper = mapper;
			_bankAccountService = bankAccountService;
			_creditCardService = creditCardService;
		}

		public async Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto paymentDto)
		{
			Result<SaveBasePaymentDto> result = new();
			try
			{
				Result<CreditCardModel> Emisor = await _creditCardService.GetByNumberIdentifierAsync(paymentDto.Receiver);

				Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);

				Receiver.Data.Amount += paymentDto.Amount;
				Emisor.Data.Amount += paymentDto.Amount + 6.25;
			
				await _bankAccountService.UpdateAsync(_mapper.Map<SaveBankAccountModel>(Emisor));

				await _creditCardService.UpdateAsync(_mapper.Map<SaveCreditCardModel>(Receiver));

				result = await base.SaveAsync(paymentDto);

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
				Result<CreditCardModel> Emisor = await _creditCardService.GetByNumberIdentifierAsync(paymentDto.Receiver);

				Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);


				if (Emisor.Data.CreditLimit < paymentDto.Amount)
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
	}
}