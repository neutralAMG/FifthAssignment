
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FifthAssignment.Infraestructure.Identity.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public UserRepository(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<List<UserGetResponceDto>> GetAllAsync()
		{
			var users = await _userManager.Users.ToListAsync();
			return users.Select(user => new UserGetResponceDto()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Cedula = user.Cedula,
				Email = user.Email,
				IsActive = user.EmailConfirmed,
				Password = user.PasswordHash,
				UserName = user.UserName


			}).ToList();
		}

		public async Task<UserGetResponceDto> GetByIdAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return null;

			var user = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

			UserGetResponceDto responce = new()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Cedula = user.Cedula,
				Email = user.Email,
				IsActive = user.EmailConfirmed,
				Password = user.PasswordHash,
				UserName = user.UserName


			};
			return responce;
		}

		public async Task<List<UserGetResponceDto>> GetUserBeneficiariesAsync(List<string> beneficiariesIds)
		{
			List<ApplicationUser> userBeneficiaries = await _userManager.Users.Where(u => beneficiariesIds.Contains(u.Id)).ToListAsync();

			return userBeneficiaries.Select(b => new UserGetResponceDto()
			{
				Id = b.Id,
				FirstName = b.FirstName,
				LastName = b.LastName,
				Cedula = b.Cedula,
				Email = b.Email,
				IsActive = b.EmailConfirmed,
				Password = b.PasswordHash,
				UserName = b.UserName
			}).ToList();
		}
		public async Task<UserGetResponceDto> GetUserBeneficiaryAsync( string beneficiaryId)
		{

			ApplicationUser beneficiary =  await _userManager.Users.Where(u => u.Id == beneficiaryId).FirstOrDefaultAsync();

			if (beneficiary == null) return null;
			UserGetResponceDto responce = new()
			{
				Id = beneficiary.Id,
				FirstName = beneficiary.FirstName,
				LastName = beneficiary.LastName,
				Cedula = beneficiary.Cedula,
				Email = beneficiary.Email,
				IsActive = beneficiary.EmailConfirmed,
				Password = beneficiary.PasswordHash,
				UserName = beneficiary.UserName

			};

			return responce;
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

		public async Task<bool> DeActivateAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return false;

			ApplicationUser userToBeDeActivated = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
;
			userToBeDeActivated.EmailConfirmed = false;

			IdentityResult result = await _userManager.UpdateAsync(userToBeDeActivated);

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


		public async Task<bool> UpdateAsync(UpdateUserDto user)
		{
			ApplicationUser userToBeUpdate = await _userManager.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();

			userToBeUpdate.FirstName = user.FirstName;
			userToBeUpdate.LastName = user.LastName;
			userToBeUpdate.Cedula = user.Cedula;
			userToBeUpdate.Email = user.Email;
			userToBeUpdate.UserName = user.UserName;
			userToBeUpdate.PasswordHash = user.PasswordHash;

			if (_userManager.FindByNameAsync(user.UserName) != null) return false;


			IdentityResult result = await _userManager.UpdateAsync(userToBeUpdate);

			if (!result.Succeeded) return false;

			return false;
		}

		public async Task<List<int>> AmountOfActiveAndInactiveUsersAsync()
		{
			int AmountOfActiveUsers = _userManager.Users.Where(u => u.EmailConfirmed == true).Count();
			int AmountOfUnActiveUsers = _userManager.Users.Where(u => u.EmailConfirmed == false).Count();
			List<int> ints = new() { AmountOfActiveUsers, AmountOfUnActiveUsers };
			return ints;
		}
	}
}
