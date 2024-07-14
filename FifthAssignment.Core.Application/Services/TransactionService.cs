
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;

namespace FifthAssignment.Core.Application.Services
{
	public class TransactionService : ITransactionStrategy
	{
		private readonly IExpressPaymentService _expressPaymentService;
		private readonly IBeneficiaryPaymentService _beneficiaryPaymentService;
		private readonly ICreditCardPaymentService _creditCardPaymentService;
		private readonly ILoanPaymentService _loanPaymentService;
		private readonly IMoneyAdvanceService _moneyAdvaceService;
		private readonly ITransferService _transferService;



		public TransactionService(
			IExpressPaymentService expressPaymentService,
			IBeneficiaryPaymentService beneficiaryPaymentService,
			ICreditCardPaymentService creditCardPaymentService,
			ILoanPaymentService loanPaymentService,
			ITransferService transferService,
			IMoneyAdvanceService moneyAdvaceService)
		{
			_expressPaymentService = expressPaymentService;
			_beneficiaryPaymentService = beneficiaryPaymentService;
			_creditCardPaymentService = creditCardPaymentService;
			_loanPaymentService = loanPaymentService;
			_transferService = transferService;
			_moneyAdvaceService = moneyAdvaceService;
		}

		private Dictionary<int, ITransaction> GetTransactionStrategies()
		{

			Dictionary<int, ITransaction> transactionStrategys = new()
	        {
		           {(int)TransactionTypes.ExpressPayment, _expressPaymentService},
		           {(int)TransactionTypes.BeneficiaryPayment, _beneficiaryPaymentService },
		           {(int)TransactionTypes.CreditCardPayment, _creditCardPaymentService },
		           {(int)TransactionTypes.LoanPayment, _loanPaymentService },
		           {(int)TransactionTypes.Transfer, _transferService },
		           {(int)TransactionTypes.MoneyAdvance, _moneyAdvaceService },
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
