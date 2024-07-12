using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using Microsoft.AspNetCore.Identity;

namespace FifthAssignment.Infraestructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
	{
		public string FirstName  { get; set; }
		public string LastName  { get; set; }
		public string Cedula { get; set; }

	}
}
