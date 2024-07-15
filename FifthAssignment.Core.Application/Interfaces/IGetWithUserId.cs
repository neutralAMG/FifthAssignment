using FifthAssignment.Core.Application.Core;


namespace FifthAssignment.Core.Application.Interfaces
{
	public interface IGetWithUserId<TGetModel> where TGetModel : class
	{
		Task<Result<List<TGetModel>>> GetAllWithCurrentUserIdAsync();
		Task<Result<List<TGetModel>>> GetAllWithAnSpecificUserIdAsync(string Id);
	}

}
