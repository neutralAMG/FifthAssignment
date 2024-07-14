
namespace FifthAssignment.Core.Application.Models.UserModels
{
	public class SaveUserModel
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Cedula { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string ComfirmPassword { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public double Amount { get; set; }
		public bool IsAdMin { get; set; }
	}
}
