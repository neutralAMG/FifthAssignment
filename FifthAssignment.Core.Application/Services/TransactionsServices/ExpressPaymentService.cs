

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Domain.Entities.PaymentContext;


namespace FifthAssignment.Core.Application.Services.PaymentServices
{
    public class ExpressPaymentService : BasePaymentService<ExpressPayment>, IExpressPaymentService
    {
        private readonly IExpressPaymentRepository _expressPaymentRepository;
        private readonly IMapper _mapper;
        private readonly IBankAccountService _bankAccountService;
		private readonly IPaymentService _paymentService;

		public ExpressPaymentService(IExpressPaymentRepository expressPaymentRepository, IMapper mapper, IBankAccountService bankAccountService, IPaymentService paymentService) : base(expressPaymentRepository, mapper)
        {
            _expressPaymentRepository = expressPaymentRepository;
            _mapper = mapper;
            _bankAccountService = bankAccountService;
			_paymentService = paymentService;
		}

        public async Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto paymentDto)
        {
            Result<SaveBasePaymentDto> result = new();
            try
            {
                Result<BankAccountModel> Emisor = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);

                Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Receiver);

                Emisor.Data.Amount -= paymentDto.Amount;

                Receiver.Data.Amount += paymentDto.Amount;

                await _bankAccountService.UpdateAsync(_mapper.Map<SaveBankAccountModel>(Emisor));

                await _bankAccountService.UpdateAsync(_mapper.Map<SaveBankAccountModel>(Receiver));

                result = await base.SaveAsync(paymentDto);

                if (!result.IsSuccess)
                {
                    result.IsSuccess = false;
                    result.Message = "Error while processing the payment";
                    return result;
                }
                result.Message = "Payment succesfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error while processing the previous payment";
                return result;
            }
        }

        public async Task<Result<bool>> ValidateTransaction(SaveBasePaymentDto paymentDto)
        {
            Result<bool> result = new();
            try
            {
                Result<BankAccountModel> Emisor = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);
                if (!Emisor.IsSuccess || Emisor.Data == null)
                {
                    result.IsSuccess = false;
                    result.Message = Emisor.Message;
                    result.Data = false;
                    return result;
                }

                Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Receiver);

                if (!Receiver.IsSuccess || Receiver.Data == null)
                {
                    result.IsSuccess = false;
                    result.Message = Receiver.Message;
                    result.Data = false;
                    return result;
                }

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

		public override async Task<Result<SaveBasePaymentDto>> SaveAsync(SaveBasePaymentDto entity)
		{
			var result = await base.SaveAsync(entity);

			if (result.IsSuccess)
			{
				await _paymentService.SaveAsync(new SavePaymentDto
				{
					Amount = entity.Amount,
					BeneficiaryPaymentId = result.Data.Id,
					PaymentTypeId = (int)TransactionTypes.ExpressPayment
				});
			}
			return result;
		}
	}
}
