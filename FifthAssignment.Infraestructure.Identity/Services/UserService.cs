using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Identity.Services
{
    public class UserRepository : IUserRepository<ApplicationUser>
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserRepository(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<List<ApplicationUser>> GetAllAsync()
		{
			return await _userManager.Users.Include(u => u.BankAccoounts)
				.Include(u => u.CreditCards)
				.Include(u => u.Loans)
				.Include(u => u.Beneficiaries).ToListAsync();
		}

		public async Task<ApplicationUser> GetByIdAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return null;

			return await _userManager.Users.Include(u => u.BankAccoounts)
				.Include(u => u.CreditCards)
				.Include(u => u.Loans)
				.Include(u => u.Beneficiaries).Where(u => u.Id == id).FirstOrDefaultAsync();
		}
		public async Task<bool> ActivateAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return false;

			ApplicationUser userToBeActivated = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

			string token = await _userManager.GenerateEmailConfirmationTokenAsync(userToBeActivated);

			IdentityResult result = await _userManager.ConfirmEmailAsync(userToBeActivated, token);

			if (!result.Succeeded) return false;

			return true;

		}

		public async Task<bool> DeleteAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return false;

			ApplicationUser userToBeDelete = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();


			IdentityResult result = await _userManager.DeleteAsync(userToBeDelete);

			if (!result.Succeeded) return false;
			

			return true;
		}


		public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
		{
			ApplicationUser userToBeUpdate = await _userManager.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();

			userToBeUpdate.FirstName = user.FirstName;
			userToBeUpdate.LastName = user.LastName;
			userToBeUpdate.Cedula = user.Cedula;
			userToBeUpdate.Email = user.Email;
			userToBeUpdate.UserName = user.UserName;
			userToBeUpdate.PasswordHash = user.PasswordHash;

			if (_userManager.FindByNameAsync(user.UserName) != null) return null;


		     IdentityResult result = await _userManager.UpdateAsync(userToBeUpdate);

			if (!result.Succeeded) return null;

			return user;
		}
	}
}
