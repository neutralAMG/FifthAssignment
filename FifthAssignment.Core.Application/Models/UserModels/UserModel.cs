using System.ComponentModel.DataAnnotations;

namespace FifthAssignment.Core.Application.Models.UserModel
{
    public class UserModel
    {
		public string? Id { get; set; }
		[Required(ErrorMessage = "First name is a requiered fild") ]
		public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is a requiered fild")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Cedula is a requiered fild")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "User name is a requiered fild")]
        public string UserName { get; set; }

        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is a requiered fild")]
        public string Email { get; set; }
        public List<string>? Roles { get; set; }
		public bool IsActive { get; set; }
		public string? IsAdmin { get; set; }
	}
}
