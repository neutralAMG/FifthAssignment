

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public record AuthenticationResponse
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public bool IsActive { get; set; }
		public bool HasError { get; set; }
		public string ErrorMessage { get; set; }
        public bool IsAdmin  => Roles.Contains("Admim") ? true : false;
    }
}
