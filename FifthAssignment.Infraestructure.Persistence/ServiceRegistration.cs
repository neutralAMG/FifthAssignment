

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Settings;
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
			services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));
			services.AddTransient<IBankAccountRepository, BankAccountRepository>();
			services.AddTransient<IBeneficiaryRepository, BeneficiaryRepository>();
			services.AddTransient<ILoanRepository, LoanRepository>();
			services.AddTransient<ICreditCardRepository, CreditCardRepository>();
			
		}
	}
}
