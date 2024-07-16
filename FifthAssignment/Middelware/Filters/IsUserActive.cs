using FifthAssignment.Controllers;
using FifthAssignment.Presentation.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FifthAssignment.Presentation.WebApp.Middelware.Filters
{
    public class IsUserActive : IAsyncActionFilter
    {
		private readonly IUserVerification _userVerification;

		public IsUserActive(IUserVerification userVerification)
		{
			_userVerification = userVerification;
		}
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!_userVerification.IsUserActive())
			{
			
					var controller = (ControllerBase)context.Controller;
					context.Result = controller.RedirectToAction("UnActivateAccount", "Home");
			
			
			}
			else
			{
				await next();
			}
		}
	}
}
