
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Models;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IHomeService
	{
		Task<Result<HomeInformationGetModel>> GetHomeInformationAsync();
	}
}
