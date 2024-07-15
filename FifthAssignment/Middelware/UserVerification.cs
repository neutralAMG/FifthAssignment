using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using Microsoft.AspNetCore.Http;

namespace FifthAssignment.Presentation.WebApp.Middelware
{
	public  class UserVerification : IUserVerification
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserVerification(IHttpContextAccessor httpContextAccessor)
        {
			_httpContextAccessor = httpContextAccessor;

		}
        public  bool UserRoleIsAdminVerification()
		{
			if (_httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user") is null) return false;
			return _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").Roles.Contains("Admim");
		}

		public bool IsLogIn()
		{
			return _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user") is null ? false : true;
		}
	}
}
