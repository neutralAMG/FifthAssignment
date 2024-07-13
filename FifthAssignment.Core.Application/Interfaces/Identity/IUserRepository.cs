using FifthAssignment.Core.Application.Dtos.AccountDtos;


namespace FifthAssignment.Core.Application.Interfaces.Identity
{
    public interface IUserRepository
    {
        Task<List<UserGetResponceDto>> GetAllAsync();
        Task<UserGetResponceDto> GetByIdAsync(string id);
        Task<List<UserGetResponceDto>> GetUserBeneficiariesAsync(List<string> ids);
        Task<UserGetResponceDto> GetUserBeneficiaryAsync(string beneficiaryId);
        Task<bool> UpdateAsync(UpdateUserDto user);
        Task<bool> DeleteAsync(string id);
        Task<bool> ActivateAsync(string id);
		Task<bool> DeActivateAsync(string id);
        Task<List<int>> AmountOfActiveAndInactiveUsersAsync();


	}
}
