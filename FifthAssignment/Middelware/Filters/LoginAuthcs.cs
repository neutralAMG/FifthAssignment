using FifthAssignment.Presentation.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FifthAssignment.Presentation.WebApp.Middelware.Filters
{
    public class LoginAuthcs : IAsyncActionFilter
    {
        private readonly IUserVerification _userVerification;

        public LoginAuthcs(IUserVerification userVerification)
        {
            _userVerification = userVerification;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userVerification.IsLogIn())
            {
                if (_userVerification.UserRoleIsAdminVerification())
                {
                    var controller = (AccountController)context.Controller;
                    context.Result = controller.RedirectToAction("AdminHomePage", "Home");
                }
                if (!_userVerification.UserRoleIsAdminVerification())
                {
                    var controller = (AccountController)context.Controller;
                    context.Result = controller.RedirectToAction("ClientHomePage", "Home");
                }
            }
            else
            {
                await next();
            }
        }
    }
}
