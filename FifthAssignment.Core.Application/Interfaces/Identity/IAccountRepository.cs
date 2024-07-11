using FifthAssignment.Core.Application.Dtos.AccountDtos;

namespace FifthAssignment.Core.Application.Interfaces.Identity
{
    public interface IAccountRepository
    {
        Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request);
        Task LogoutAsync();
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task ForgotPasswordAsync();
    }
}
