
using System.ComponentModel.DataAnnotations;

namespace FifthAssignment.Core.Application.Models.UserModels
{
	public class SaveUserModel
	{
		public string? Id { get; set; }
        [Required(ErrorMessage = "Frist name is a requiered fild")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is a requiered fild")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Cedula is a requiered fild")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "user name is a requiered fild")]
        public string UserName { get; set; }
        public string? Password { get; set; }
		public string? ComfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is a requiered fild")]
        public string Email { get; set; }
		public List<string>? Roles { get; set; }
		public decimal Amount { get; set; }
		public bool IsAdMin { get; set; }

	}
}
