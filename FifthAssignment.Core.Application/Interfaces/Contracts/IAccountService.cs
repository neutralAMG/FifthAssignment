
using FifthAssignment.Core.Application.Dtos.AccountDtos;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IAccountService
	{
		Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request);

		Task LogoutAsync();

		Task<RegisterResponse> RegisterClientAsync(RegisterRequest request);
		Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request);
		Task EditUserAsync(RegisterRequest request);

		Task ForgotPasswordAsync();
		Task ChangePasswordAsync();


	}
}
