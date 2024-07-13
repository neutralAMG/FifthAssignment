

using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Application.Interfaces.Repositories;
using FifthAssignment.Core.Application.Models;
using FifthAssignment.Core.Domain.Core;

namespace FifthAssignment.Core.Application.Services
{
	public class HomeService : IHomeService
	{
		private readonly IHomeRepository _homeRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public HomeService(IHomeRepository homeRepository, IUserRepository userRepository, IMapper mapper)
        {
			_homeRepository = homeRepository;
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<Result<HomeInformationGetModel>> GetHomeInformationAsync()
		{
			Result<HomeInformationGetModel> result = new();
			try
			{
				HomeInformation InfoGetted = await _homeRepository.GetHomeInformationAsync();

				result.Data = _mapper.Map<HomeInformationGetModel>(InfoGetted);
				List<int> ints = await _userRepository.AmountOfActiveAndInactiveUsersAsync();
				result.Data.AmountOfActiveUsers = ints[0]; 
				result.Data.AmountOfUnActive = ints[1]; 

				result.Message = "Info get was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error getting the information";
				return result;
			}
		}
	}
}
