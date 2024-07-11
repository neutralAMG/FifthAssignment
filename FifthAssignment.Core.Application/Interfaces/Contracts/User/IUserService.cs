
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Models.UserModels;

namespace FifthAssignment.Core.Application.Interfaces.Contracts.User
{
	public interface IUserService
	{
		Task<Result<List<UserModel>>> GetAllAsync();
		Task<Result<UserModel>> GetByIdAsync(string id);
		Task<Result<List<UserModel>>> GetUserBeneficiariesAsync();
		Task<Result<UserModel>> GetUserBeneficiarieAsync(string beneficiaryId);
		Task<Result<SaveUserModel>> UpdateAsync(SaveUserModel user);
		Task<Result<UserModel>> DeleteAsync(string id);
		Task<Result<UserModel>> ActivateAsync(string id);
		Task<Result<UserModel>> DeActivateAsync(string id);


	}
}
