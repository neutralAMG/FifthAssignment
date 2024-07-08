using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Infraestructure.Identity.Entities;
using FifthAssignment.Infraestructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;


namespace FifthAssignment.Infraestructure.Identity.Services
{
    public class AccountService : IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

        public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
		{
			AuthenticationResponse response = new();

			ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				response.HasError = true;
				response.ErrorMessage = "Incorrect email";
				return response;
			}

			SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false).ConfigureAwait(true);

			if (!result.Succeeded) {
				response.HasError = true;
				response.ErrorMessage = "Incorrect Password";
				return response;
			}


			response.Id = user.Id;
			response.UserName = user.UserName;
			response.Email = user.Email;
			response.IsActive = user.EmailConfirmed;
			response.HasError = false;
			var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
			response.Roles = roleList.ToList();
			response.Id = user.Id;
			return response;
		}

		public async Task LogoutAsync()
		{
			 await _signInManager.SignOutAsync();
		}

		public async Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request)
		{
			RegisterResponse response = new();

            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName);
			
			if(user != null)
			{
				response.HasError = true;
				response.ErrorMessage = $"There is already a user with the username: {request.UserName} ";
				return response;
			}
			ApplicationUser userToBeSaved = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				Cedula = request.Cedula,
				EmailConfirmed = false,
				PasswordHash = request.Password,
				
			};

			IdentityResult result = await _userManager.CreateAsync(user);

			if (!result.Succeeded) { 
				response.HasError = true;
				response.ErrorMessage = "Error saving the user :" + result.Errors.FirstOrDefault();
				return response;
			}

			await _userManager.AddToRoleAsync(userToBeSaved, Roles.Admim.ToString());
			return response;
		}

		public async Task<RegisterResponse> RegisterClientAsync(RegisterRequest request)
		{
			RegisterResponse response = new();
			
			ApplicationUser UserWithSameUsername = await _userManager.FindByNameAsync(request.UserName);

			if (UserWithSameUsername != null) {
				response.HasError = true;
				response.ErrorMessage = $"There's already a user with the email: {request.Email}";
				return response;

			}

			ApplicationUser userToBeSave = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				Cedula = request.Cedula,
				EmailConfirmed = false,
				PasswordHash = request.Password,
			};
			IdentityResult result = await _userManager.CreateAsync(userToBeSave, request.Password);

			if (!result.Succeeded) { 
			    response.HasError= true;
				response.ErrorMessage = "Error Saving the user";
				return response;
			}

			await _userManager.AddToRoleAsync(userToBeSave, Roles.client.ToString());
			return response;
		}		
		
		public async Task ChangePasswordAsync()
		{
			throw new NotImplementedException();
		}

		public async Task ForgotPasswordAsync()
		{
			throw new NotImplementedException();
		}
	}
}
