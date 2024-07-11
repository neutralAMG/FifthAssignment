

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Models.UserModels;

namespace FifthAssignment.Core.Application.Interfaces.Contracts.User
{
	public interface IAccountService
	{
		Task<Result<AuthenticationResponse>> LoginAsync(string email, string password);
		Task LogoutAsync();
		Task<Result<RegisterResponse>> RegisterAsync(SaveUserModel Model);
	}
}
