

using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Settings;
using FifthAssignment.Infraestructure.Transaction.Repositories;
using FifthAssignment.Infraestructure.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Infraestructure.Transaction
{
	public static class ServiceRegistration
	{
		public static void AddInfraestructureTransactionLayer(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<PaymentContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(PaymentContext).Assembly.FullName));
			});

		//	services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));

			services.AddTransient<IBeneficiaryPaymentRepository, BeneficiaryPaymentRepository>();
			services.AddTransient<ICreditcardPaymentRepository, CreditcardPaymentRepository>();
			services.AddTransient<IExpressPaymentRepository, ExpressPaymentRepository>();
			services.AddTransient<ILoanPaymentRepository, LoanPaymentRepository>();
			services.AddTransient<ITransactionRepository, TransactionRepository>();
			services.AddTransient<ITransferRepository, TransferRepository>();

		}
	}
}
