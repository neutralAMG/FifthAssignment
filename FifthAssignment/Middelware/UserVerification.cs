using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Utils.SessionHandler;

namespace FifthAssignment.Presentation.WebApp.Middelware
{
	public  class UserVerification
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserVerification(IHttpContextAccessor httpContextAccessor)
        {
			_httpContextAccessor = httpContextAccessor;

		}
        public  bool UserRoleIsAdminVerification()
		{
			return _httpContextAccessor.HttpContext.Session.Get<UserGetResponceDto>("user").Roles.Contains("Admin");
		}
	}
}
