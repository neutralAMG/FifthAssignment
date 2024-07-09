﻿

using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FifthAssignment.Infraestructure.Identity.Seeds
{
	public static class DefaultAdminUser
	{
		public static async Task AddAdminUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			ApplicationUser DefaultUser = new() { 
			
				FirstName = "Test",	
				LastName = "Test",
				Email = "",
				UserName = "TestAdminUser",
				PasswordHash = "Test",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
			};
			if (userManager.Users.All(u => u.Id != DefaultUser.Id))
			{
				var user = await userManager.FindByNameAsync(DefaultUser.UserName);

				if (user is null) {
					await userManager.CreateAsync(DefaultUser);

					userManager.AddToRoleAsync(DefaultUser, Enums.Roles.Admim.ToString());
				}
			}

			
		}
	}
}