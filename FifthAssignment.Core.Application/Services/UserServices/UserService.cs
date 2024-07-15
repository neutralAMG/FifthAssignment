
using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Core.Application.Services.UserServices
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContext;

		private AuthenticationResponse _currentUser { get; set; }
		private SessionKeys _sessionKeys { get; set; }

		public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_httpContext = httpContext;
			_sessionKeys = sessionKeys.Value;
			_currentUser = _httpContext.HttpContext.Session.Get<AuthenticationResponse>(_sessionKeys.user);
		}

		public async Task<Result<List<UserModel>>> GetAllAsync()
		{
			Result<List<UserModel>> result = new();
			try
			{
				List<UserGetResponceDto> usersGeted = await _userRepository.GetAllAsync();

				result.Data = _mapper.Map<List<UserModel>>(usersGeted);
				result.Message = "User's get was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error getting the user's";
				return result;
			}
		}

		public async Task<Result<UserModel>> GetByIdAsync(string id)
		{
			Result<UserModel> result = new();
			try
			{
				UserGetResponceDto userGeted = await _userRepository.GetByIdAsync(id);

				result.Data = _mapper.Map<UserModel>(userGeted);

				result.Message = "User get was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error getting the user";
				return result;

			}
		}
		public async Task<Result<UserModel>> GetUserBeneficiarieAsync(string beneficiaryId)
		{
			Result<UserModel> result = new();
			try
			{
				UserGetResponceDto userGeted = await _userRepository.GetUserBeneficiaryAsync(beneficiaryId);

				result.Data = _mapper.Map<UserModel>(userGeted);
				result.Message = "Beneficiary get was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error getting the Beneficiary";
				return result;

			}
		}


		public async Task<Result<UserModel>> ActivateAsync(string id)
		{
			Result<UserModel> result = new();
			try
			{
				bool operationResult = await _userRepository.ActivateAsync(id);

				if (!operationResult)
				{
					result.IsSuccess = false;
					result.Message = "User activation was unsuccesfull";
					return result;
				}
				result.Message = "User activation was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error activating the user";
				return result;

			}
		}

		public async Task<Result<UserModel>> DeActivateAsync(string id)
		{
			Result<UserModel> result = new();
			try
			{
				bool operationResult = await _userRepository.DeActivateAsync(id);

				if (!operationResult)
				{
					result.IsSuccess = false;
					result.Message = "User deactivation was unsuccesfull";
					return result;
				}
				result.Message = "User deactivation was succesfull";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error deactivating the user";
				return result;

			}
		}
		public async Task<Result<SaveUserModel>> UpdateAsync(SaveUserModel user)
		{
			Result<SaveUserModel> result = new();
			try
			{
				UpdateUserDto userToBeUpdate = _mapper.Map<UpdateUserDto>(user);

				bool operationResult = await _userRepository.UpdateAsync(userToBeUpdate);

				if (!operationResult)
				{
					result.IsSuccess = false;
					result.Message = "Error updating the user";
					return result;
				}
				result.Message = "User update was succesfull";
				return result;

			}
			catch
			{
				result.IsSuccess= false;
				result.Message = "Critical error updating the user";
				return result;
			}
		}
		public async Task<Result<UserModel>> DeleteAsync(string id)
		{
			Result<UserModel> result = new();
			try
			{

				bool operationResult = await _userRepository.DeleteAsync(id);

				if (!operationResult)
				{
					result.IsSuccess = false;
					result.Message = "Error deleting the user";
					return result;
				}
				result.Message = "User deleted was succesfull";
				return result;

			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error deleting the user";
				return result;
			}
		}


	}
}
