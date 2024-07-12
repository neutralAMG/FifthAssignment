

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public record RegisterResponse
	{
		public bool HasError { get; set; }
		public string Id  { get; set; }
		public string ErrorMessage { get; set; }

	}
}
