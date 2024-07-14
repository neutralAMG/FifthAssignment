using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;

namespace FifthAssignment.Presentation.WebApp
{
	public static class ServiceRegistration 
	{
		public static void AddPresentationLayer(this IServiceCollection services)
		{
			services.AddTransient<IGenerateAppSelectList, GenerateAppSelectList>();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Account/LogIn";
				options.AccessDeniedPath = "";
			});
		}
	}
}
