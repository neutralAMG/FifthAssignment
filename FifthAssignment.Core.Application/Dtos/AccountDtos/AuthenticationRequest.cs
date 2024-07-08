

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public record AuthenticationRequest
	{
		public string Email {  get; set; }
		public string Password {  get; set; }
	}
}
