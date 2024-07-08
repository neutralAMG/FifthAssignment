namespace FifthAssignment.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository<TUser> where TUser : class
    {
        Task<List<TUser>> GetAllAsync();
        Task<TUser> GetByIdAsync(string id);
        Task<TUser> UpdateAsync(TUser user);
        Task<bool> DeleteAsync(string id);
        Task<bool> ActivateAsync(string id);
    }
}
