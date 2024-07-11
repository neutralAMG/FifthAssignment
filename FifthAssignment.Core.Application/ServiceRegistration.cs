
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Services;
using FifthAssignment.Core.Application.Services.CoreServices;
using FifthAssignment.Core.Application.Services.PaymentServices;
using FifthAssignment.Core.Application.Services.TransactionsServices;
using FifthAssignment.Core.Application.Utils.GenerateProductCodeString;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Core.Application
{
	public static class ServiceRegistration
	{
		public static void AddCoreAplicationLayer(this IServiceCollection services, IConfiguration confi)
		{

			services.Configure<SessionKeys>(confi.GetSection("SessionKeys"));

			services.AddTransient<ICodeGenerator, GenerateACodeString>();

			services.AddTransient<IBankAccountService, BankAccountService>();
			services.AddTransient<ICreditCardService, CreditCardService>();
			services.AddTransient<IBeneficiaryService, BeneficiaryService>();
			services.AddTransient<ILoanService, LoanService>();

			services.AddTransient<IBeneficiaryPaymentService, BeneficiaryPaymentService>();
			services.AddTransient<IExpressPaymentService, ExpressPaymentService>();
			services.AddTransient<ICreditCardPaymentService, CreditCardPaymentService>();
			services.AddTransient<ILoanPaymentService, LoanPaymentService>();
			services.AddTransient<ITransferService, TransferService>();
			services.AddTransient<IMoneyAdvanceService, MoneyAdvanceService>();
			services.AddTransient<ITransactionService, TransactionService>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}
	}
}
