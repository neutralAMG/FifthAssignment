
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;

namespace FifthAssignment.Core.Application.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly IExpressPaymentService _expressPaymentService;
		private readonly IBeneficiaryPaymentService _beneficiaryPaymentService;
		private readonly ICreditCardPaymentService _creditCardPaymentService;
		private readonly ILoanPaymentService _loanPaymentService;
		private readonly IMoneyAdvaceService _moneyAdvaceService;
		private readonly ITransferService _transferService;



		public TransactionService(
			IExpressPaymentService expressPaymentService,
			IBeneficiaryPaymentService beneficiaryPaymentService,
			ICreditCardPaymentService creditCardPaymentService,
			ILoanPaymentService loanPaymentService,
			ITransferService transferService,
			IMoneyAdvaceService moneyAdvaceService)
		{
			_expressPaymentService = expressPaymentService;
			_beneficiaryPaymentService = beneficiaryPaymentService;
			_creditCardPaymentService = creditCardPaymentService;
			_loanPaymentService = loanPaymentService;
			_transferService = transferService;
			_moneyAdvaceService = moneyAdvaceService;
		}

		private Dictionary<int, IPay> GetTransactionStrategies()
		{

			Dictionary<int, IPay> transactionStrategys = new()
	        {
		           {1, _expressPaymentService},
		           {2, _beneficiaryPaymentService },
		           {3, _creditCardPaymentService },
		           {4, _loanPaymentService },
		           {5, _transferService },
		           {6, _moneyAdvaceService },
	        };

			return transactionStrategys;
		}

		public async Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto saveBasePaymentDto)
		{
		  return await GetTransactionStrategies()[saveBasePaymentDto.TransactionType].MakeTransaction(saveBasePaymentDto);
		}

		public async Task<Result<bool>> MakeValidation(SaveBasePaymentDto saveBasePaymentDto)
		{
		 return await GetTransactionStrategies()[saveBasePaymentDto.TransactionType].ValidateTransaction(saveBasePaymentDto);
		}
	}
}
