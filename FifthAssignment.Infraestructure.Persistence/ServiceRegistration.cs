

using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Infraestructure.Persistence.Context;
using FifthAssignment.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Infraestructure.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddInfraestructurePercistanceLayer(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<fifthAssignmentContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(fifthAssignmentContext).Assembly.FullName));
			});
			//services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));
			services.AddTransient<IBankAccountRepository, BankAccountRepository>();
			services.AddTransient<IBeneficiaryRepository, BeneficiaryRepository>();
			services.AddTransient<ILoanRepository, LoanRepository>();
			services.AddTransient<ICreditCardRepository, CreditCardRepository>();

			services.AddTransient<IBeneficiaryPaymentRepository, BeneficiaryPaymentRepository>();
			services.AddTransient<ICreditcardPaymentRepository, CreditcardPaymentRepository>();
			services.AddTransient<IExpressPaymentRepository, ExpressPaymentRepository>();
			services.AddTransient<ILoanPaymentRepository, LoanPaymentRepository>();
			services.AddTransient<ITransactionRepository, TransactionRepository>();
			services.AddTransient<ITransferRepository, TransferRepository>();

			services.AddTransient<IHomeRepository, HomeRepository>();
		}
	}
}
