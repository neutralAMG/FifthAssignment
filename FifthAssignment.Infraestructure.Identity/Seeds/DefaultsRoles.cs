

using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FifthAssignment.Infraestructure.Identity.Seeds
{
	public static class DefaultsRoles
	{

		public static async Task AddDefaultRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admim.ToString()));

			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.client.ToString()));

			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
		}
	}
}
