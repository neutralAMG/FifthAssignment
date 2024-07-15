using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		// GET: AccountController/Create
		public async Task<IActionResult> LogIn()
		{
			return View();
		}



		// POST: AccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogIn(string Email, string Password)
		{

			Result<AuthenticationResponse> result = new();
			try
			{
				result = await _accountService.LoginAsync(Email, Password);
				if (!result.IsSuccess)
				{
					ViewBag.MessageError = result.Message;
					return View();
				}

				if (TempData[MessageType.MessageError.ToString()] != null)
				{
					ViewBag.MessageError = TempData[MessageType.MessageError.ToString()];
				}
				if (TempData[MessageType.MessageSuccess.ToString()] != null)
				{
					ViewBag.MessageSuccess = TempData[MessageType.MessageSuccess.ToString()];
				}

				if (result.Data.Roles.Contains("Admim"))
				{
					return RedirectToAction("AdminHomePage", "Home");
				}
				return RedirectToAction("ClientHomePage", "Home");
			}
			catch
			{
				return View();
			}
		}
		// GET: AccountController/Create
		public async Task<IActionResult> LogOut()
		{
			await _accountService.LogoutAsync();

			return View("LogIn");
		}


		// GET: AccountController/Create
		public async Task<IActionResult> RegisterUser()
		{
			return View();
		}



		// POST: AccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RegisterUser(SaveUserModel saveModel)
		{
			Result<RegisterResponse> result = new();
			try
			{
				result = await _accountService.RegisterAsync(saveModel);

				if (!result.IsSuccess)
				{
					ViewBag[MessageType.MessageError.ToString()] = result.Message;
					return View();
				}
				ViewBag[MessageType.MessageSuccess.ToString()] = "User was created succesfully";

				return RedirectToAction("Index", "User");
			}
			catch
			{
				return View();
			}
		}


	}
}
