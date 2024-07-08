

using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Domain.Settings;
using FifthAssignment.Infraestructure.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Infraestructure.Persistence
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

		}
	}
}
