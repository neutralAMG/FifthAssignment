

namespace FifthAssignment.Core.Application.Dtos.AccountDtos
{
	public record  UpdateUserDto
	{
		public string Id { get; set; }	
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Cedula { get; set; }
		public string Email {  get; set; }
		public string	UserName {  get; set; }
		public string PasswordHash { get; set; }	
	}
}
