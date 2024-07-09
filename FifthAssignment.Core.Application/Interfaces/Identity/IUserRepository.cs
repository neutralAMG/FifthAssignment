using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Models;

namespace FifthAssignment.Core.Application.Interfaces.Identity
{
    public interface IUserRepository
    {
        Task<List<UsserGetResponceDto>> GetAllAsync();
        Task<UsserGetResponceDto> GetByIdAsync(string id);
        Task<bool> UpdateAsync(UpdateUserDto user);
        Task<bool> DeleteAsync(string id);
        Task<bool> ActivateAsync(string id);
    }
}
