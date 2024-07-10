
using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Services
{
	internal class CreditCardPaymentService : BasePaymentService<CreditcardPayment>, ICreditCardPaymentService
	{
		private readonly ICreditcardPaymentRepository _creditcardPaymentRepository;
		private readonly IMapper _mapper;
		private readonly IBankAccountService _bankAccountService;
		private readonly ICreditCardService _creditCardService;

		public CreditCardPaymentService(ICreditcardPaymentRepository creditcardPaymentRepository, IMapper mapper, IBankAccountService bankAccountService, ICreditCardService creditCardService) : base(creditcardPaymentRepository, mapper)
		{
			_creditcardPaymentRepository = creditcardPaymentRepository;
			_mapper = mapper;
			_bankAccountService = bankAccountService;
			_creditCardService = creditCardService;
		}

		public async Task<Result<SaveBasePaymentDto>> Pay(SaveBasePaymentDto paymentDto)
		{
			Result<SaveBasePaymentDto> result = new();
			try
			{
				Result<BankAccountModel> Emisor = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);

				Result<CreditCardModel> Receiver = await _creditCardService.GetByNumberIdentifierAsync(paymentDto.Receiver);


			    double operationResidue = Receiver.Data.Amount - paymentDto.Amount;

				if (operationResidue > 0)
				{
					Emisor.Data.Amount += operationResidue;
					Emisor.Data.Amount = operationResidue;
				}else if(operationResidue < 0)
				{
					Emisor.Data.Amount += Math.Abs(operationResidue);
					Emisor.Data.Amount = 0;
				}
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

		public async Task<Result<bool>> ValidatePayment(SaveBasePaymentDto paymentDto)
		{
			Result<bool> result = new();
			try
			{
				Result<BankAccountModel> Emisor = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);

			//	Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Receiver);

				if (Emisor.Data.Amount < paymentDto.Amount)
				{
					result.IsSuccess = false;
					result.Message = "You have not enough money on your account to do this transaction";
					return result;
				}
				result.Message = "transaction authorized";
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
