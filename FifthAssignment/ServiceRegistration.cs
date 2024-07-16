using FifthAssignment.Presentation.WebApp.Middelware;
using FifthAssignment.Presentation.WebApp.Middelware.Filters;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;

namespace FifthAssignment.Presentation.WebApp
{
    public static class ServiceRegistration 
	{
		public static void AddPresentationLayer(this IServiceCollection services)
		{
			services.AddTransient<IGenerateAppSelectList, GenerateAppSelectList>();
			services.AddScoped<LoginAuthcs>();
			services.AddScoped<IsUserActive>();
			services.AddScoped<UserIsLogIn>();
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<IUserVerification, UserVerification>();

		}
	}
}
