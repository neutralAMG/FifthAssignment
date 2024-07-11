
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
    public class BeneficiaryPaymentService : BasePaymentService<BeneficiaryPayment>, IBeneficiaryPaymentService
    {
        private readonly IBeneficiaryPaymentRepository _beneficiaryPaymentRepository;
        private readonly IMapper _mapper;
        private readonly IBankAccountService _bankAccountService;
		private readonly IPaymentService _paymentService;

		public BeneficiaryPaymentService(IBeneficiaryPaymentRepository beneficiaryPaymentRepository, IMapper mapper, IBankAccountService bankAccountService, IPaymentService paymentService) : base(beneficiaryPaymentRepository, mapper)
        {
            _beneficiaryPaymentRepository = beneficiaryPaymentRepository;
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

                Result<BankAccountModel> Receiver = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Receiver);

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

            if (result.IsSuccess) { 
            await _paymentService.SaveAsync(new SavePaymentDto
            {
                Amount = entity.Amount,
                BeneficiaryPaymentId = result.Data.Id,
                PaymentTypeId = (int)TransactionTypes.BeneficiaryPayment   
            });
            }
            return result;
        }

	}
}
