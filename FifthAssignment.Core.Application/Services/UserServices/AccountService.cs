﻿
using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Core.Application.Utils.SessionHandler;
using FifthAssignment.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Core.Application.Services.UserServices
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContext;
		private SessionKeys _sessionKeys { get; set; }

		public AccountService(IAccountRepository accountRepository, IMapper mapper, IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys)
        {
			_accountRepository = accountRepository;
			_mapper = mapper;
			_httpContext = httpContext;
			_sessionKeys = sessionKeys.Value;
		}
        public async Task<Result<AuthenticationResponse>> LoginAsync(string email, string password)
		{
			Result<AuthenticationResponse> result = new();
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
				{
					result.IsSuccess = false;
					result.Message = " Email and password cant be empty";
					return result;
				}
				AuthenticationResponse  user=await _accountRepository.LoginAsync(new AuthenticationRequest { Email = email, Password = password});

				_httpContext.HttpContext.Session.Set<AuthenticationResponse>(_sessionKeys.user, user);
				result.Message = "Login succesfull";
				return result;

			}
			catch
			{
				result.IsSuccess=false;
				result.Message = "Critical error authenticating the user";
				return result;
			}
		}

		public async Task LogoutAsync()
		{
			try
			{
				await _accountRepository.LogoutAsync();

				_httpContext.HttpContext.Session.Clear();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Result<RegisterResponse>> RegisterAsync(SaveUserModel saveModel)
		{
			Result<RegisterResponse> result = new();
			try
			{
				RegisterRequest request = _mapper.Map<RegisterRequest>(saveModel);

				result.Data = await _accountRepository.RegisterAsync(request);

				result.Message = "User was created succesfully";
				return result;

			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical error creating the new user";
				return result;
			}
		}
	}
}