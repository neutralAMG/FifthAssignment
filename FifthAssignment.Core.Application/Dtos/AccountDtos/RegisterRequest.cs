

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public record RegisterRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }	
		public string Cedula { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	//	public string ConfirmPassword { get; set; }
	}
}
