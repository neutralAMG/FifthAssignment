
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
		}
	}
}
