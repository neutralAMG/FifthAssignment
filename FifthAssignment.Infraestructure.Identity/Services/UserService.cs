using AutoMapper;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Identity.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}
		public async Task<List<UsserGetResponceDto>> GetAllAsync()
		{
			var users = await _userManager.Users.Include(u => u.BankAccoounts)
				.Include(u => u.CreditCards)
				.Include(u => u.Loans)
				.Include(u => u.Beneficiaries).ToListAsync();
			return _mapper.Map<List<UsserGetResponceDto>>(users);
		}

		public async Task<UsserGetResponceDto> GetByIdAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return null;

			var user = await _userManager.Users.Include(u => u.BankAccoounts)
				.Include(u => u.CreditCards)
				.Include(u => u.Loans)
				.Include(u => u.Beneficiaries).Where(u => u.Id == id).FirstOrDefaultAsync();

			return _mapper.Map<UsserGetResponceDto>(user);
		}

		public async Task<List<UsserGetResponceDto>> GetUserBeneficiariesAsync(string id)
		{
			if (!await _userManager.Users.AnyAsync(u => u.Id == id)) return null;

			var userBeneficiariesIds = await _userManager.Users.SelectMany(u => u.Beneficiaries.Where(b => b.UserId == id).Select(b => b.UserBeneficiaryId)).ToListAsync();

			List<ApplicationUser> Beneficiaries = new();

			foreach (var be in userBeneficiariesIds)
			{
				var user = await _userManager.Users.Include(u => u.BankAccoounts)
				  .Include(u => u.CreditCards)
				  .Include(u => u.Loans)
				  .Include(u => u.Beneficiaries).Where(u => u.Id == be).FirstOrDefaultAsync();

				Beneficiaries.Add(user);
			}

			return _mapper.Map<List<UsserGetResponceDto>>(Beneficiaries);
		}
		public async Task<UsserGetResponceDto> GetUserBeneficiarieAsync(string userid, string beneficiaryId)
		{

			List<UsserGetResponceDto> beneficiaries = await GetUserBeneficiariesAsync(userid);

			UsserGetResponceDto beneficiary = beneficiaries.Where(u => u.Id == beneficiaryId).FirstOrDefault();

			if (beneficiary == null) return null;

			return beneficiary;
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


	}
}
