using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;
        private readonly IGenerateAppSelectList _generateAppSelectList;

        public AccountController(IAccountService accountService, IGenerateAppSelectList generateAppSelectList)
		{
			_accountService = accountService;
            _generateAppSelectList = generateAppSelectList;
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
					ViewBag.MessageError = TempData[MessageType.MessageError.ToString()].ToString();
				}
				if (TempData[MessageType.MessageSuccess.ToString()] != null)
				{
					ViewBag.MessageSuccess = TempData[MessageType.MessageSuccess.ToString()].ToString();
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
		public async Task<IActionResult> RegisterUser(bool IsAdmin)
		{
			var select = _generateAppSelectList.GenerateUserRolesSelectList();
			ViewBag.IsAdmin = IsAdmin;
			ViewBag.role = IsAdmin ? select.Where(r => r.Value == 1.ToString()) : select.Where(r => r.Value == 2.ToString()); 
			return View(new	SaveUserModel());
		}



		// POST: AccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RegisterUser(SaveUserModel saveModel)
		{
			Result<RegisterResponse> result = new();
			try
			{
				saveModel.IsAdMin = saveModel.Amount <= 0 ? true : false;

				result = await _accountService.RegisterAsync(saveModel);

				if (saveModel.Password != saveModel.ComfirmPassword)
				{
					var select = _generateAppSelectList.GenerateUserRolesSelectList();
					ViewBag.IsAdmin = saveModel.IsAdMin;
					ViewBag.role = saveModel.IsAdMin ? select.Where(r => r.Value == 1.ToString()) : select.Where(r => r.Value == 2.ToString()); ;
					ViewBag.MessageError = result.Message;
					return View(saveModel);
				}

				if (!result.IsSuccess)
				{
					var select = _generateAppSelectList.GenerateUserRolesSelectList();
					ViewBag.IsAdmin = saveModel.IsAdMin;
					ViewBag.role = saveModel.IsAdMin ? select.Where(r => r.Value == 1.ToString()) : select.Where(r => r.Value == 2.ToString()); ;
					ViewBag.MessageError = result.Message;
					return View(saveModel);
				}
				ViewBag.MessageSuccess = "User was created succesfully";

				return RedirectToAction("Index", "User");
			}
			catch
			{
				return View();
			}
		}


	}
}
