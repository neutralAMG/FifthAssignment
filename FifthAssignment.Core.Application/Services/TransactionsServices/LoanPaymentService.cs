

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Domain.Entities.PaymentContext;


namespace FifthAssignment.Core.Application.Services.PaymentServices
{
    public class LoanPaymentService : BasePaymentService<LoanPayment>, ILoanPaymentService
    {
        private readonly ILoanPaymentRepository _loanPaymentRepository;
        private readonly IMapper _mapper;
        private readonly IBankAccountService _bankAccountService;
        private readonly ILoanService _loanService;
		private readonly IPaymentService _paymentService;

		public LoanPaymentService(ILoanPaymentRepository loanPaymentRepository, IMapper mapper, IBankAccountService bankAccountService, ILoanService loanService, IPaymentService paymentService) : base(loanPaymentRepository, mapper)
        {
            _loanPaymentRepository = loanPaymentRepository;
            _mapper = mapper;
            _bankAccountService = bankAccountService;
            _loanService = loanService;
			_paymentService = paymentService;
		}

        public async Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto paymentDto)
        {
            Result<SaveBasePaymentDto> result = new();
            try
            {
                Result<BankAccountModel> Emisor = await _bankAccountService.GetByNumberIdentifierAsync(paymentDto.Emisor);

                Result<LoanModel> Receiver = await _loanService.GetByNumberIdentifierAsync(paymentDto.Receiver);

                double operationResidue = Receiver.Data.Amount - paymentDto.Amount;

                if (operationResidue >= 0)
                {
                    Emisor.Data.Amount += operationResidue;
                    Receiver.Data.Amount = operationResidue;
                }
                else if (operationResidue < 0)
                {
                    Emisor.Data.Amount += Math.Abs(operationResidue);
                    Receiver.Data.Amount = 0;
                }
                await _bankAccountService.UpdateAsync(_mapper.Map<SaveBankAccountModel>(Emisor));
                await _loanService.UpdateAsync(_mapper.Map<SaveLoanModel>(Receiver));

                result = await base.SaveAsync(paymentDto);

                result.Message = "Payment successfull";
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

                Result<LoanModel> Receiver = await _loanService.GetByNumberIdentifierAsync(paymentDto.Receiver);

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
					PaymentTypeId = (int)TransactionTypes.LoanPayment
				});
			}
			return result;
		}
	}
}
