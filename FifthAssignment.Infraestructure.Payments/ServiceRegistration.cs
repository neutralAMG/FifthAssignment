﻿

using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Settings;
using FifthAssignment.Infraestructure.Payments.Repositories;
using FifthAssignment.Infraestructure.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Infraestructure.Payments
{
	public static class ServiceRegistration
	{
		public static void AddInfraestructurePaymentsLayer(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<PaymentContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(PaymentContext).Assembly.FullName));
			});

			services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));

			services.AddTransient<IBeneficiaryPaymentRepository, BeneficiaryPaymentRepository>();
			services.AddTransient<ICreditcardPaymentRepository, CreditcardPaymentRepository>();
			services.AddTransient<IExpressPaymentRepository, ExpressPaymentRepository>();
			services.AddTransient<ILoanPaymentRepository, LoanPaymentRepository>();
			services.AddTransient<IPaymentRepository, PaymentRepository>();
			services.AddTransient<ITransferRepository, TransferRepository>();

		}
	}
}
