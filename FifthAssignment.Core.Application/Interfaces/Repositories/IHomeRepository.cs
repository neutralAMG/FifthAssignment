using FifthAssignment.Core.Domain.Core;


namespace FifthAssignment.Core.Application.Interfaces.Repositories
{
	public interface IHomeRepository
	{
		Task<HomeInformation> GetHomeInformationAsync();
	}
}
