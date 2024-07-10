using FifthAssignment.Core.Application.Dtos.AccountDtos;


namespace FifthAssignment.Core.Application.Interfaces.Identity
{
    public interface IUserRepository
    {
        Task<List<UsserGetResponceDto>> GetAllAsync();
        Task<UsserGetResponceDto> GetByIdAsync(string id);
        Task<List<UsserGetResponceDto>> GetUserBeneficiariesAsync(string id);
        Task<UsserGetResponceDto> GetUserBeneficiarieAsync(string userid, string beneficiaryId);
        Task<bool> UpdateAsync(UpdateUserDto user);
        Task<bool> DeleteAsync(string id);
        Task<bool> ActivateAsync(string id);
		Task<bool> DeActivateAsync(string id);

	}
}
