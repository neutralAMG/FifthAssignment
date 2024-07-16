using FifthAssignment.Presentation.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FifthAssignment.Presentation.WebApp.Middelware.Filters
{
    public class UserIsLogIn : IAsyncActionFilter
    {
		private readonly IUserVerification _userVerification;

		public UserIsLogIn(IUserVerification userVerification)
		{
			_userVerification = userVerification;
		}
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!_userVerification.IsLogIn())
			{

				var controller = (ControllerBase)context.Controller;
				context.Result = controller.RedirectToAction("LogIn", "Account");


			}
			else
			{
				await next();
			}
		}
	}
}
