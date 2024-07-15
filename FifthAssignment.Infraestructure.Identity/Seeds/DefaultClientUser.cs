using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Infraestructure.Identity.Entities;
using FifthAssignment.Infraestructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthAssignment.Infraestructure.Identity.Seeds
{
	public static class DefaultClientUser
	{

		public static async Task AddDefaultClientUser(IBankAccountService bankAccountService,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			ApplicationUser user = new()
			{
				FirstName = "Test",
				LastName = "Test",
				Email = "EmailClient@gmail.com",
				UserName = "TestClienntUser",
				Cedula = "2345678531",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true

            };
			if (!userManager.Users.Any(u => u.Id == user.Id))
			{
				ApplicationUser userWithSameUserUserName = await userManager.FindByNameAsync(user.UserName);

				if (userWithSameUserUserName == null)
				{
					await userManager.CreateAsync(user, "123Test!");
					await userManager.AddToRoleAsync(user, Roles.client.ToString());
					await bankAccountService.SaveAsync(new Core.Application.Models.BankAccountsModels.SaveBankAccountModel { Amount = 500.72m, IdentifierNumber = "111111111", IsMain = true, UserId = user.Id });
				}
			}

		}
	}
}
