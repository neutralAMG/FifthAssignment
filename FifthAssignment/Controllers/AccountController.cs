using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.AccountDtos;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.UserModels;
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
        // GET: AccountController
        public ActionResult Index()
		{
			return View();
		}

		// GET: AccountController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: AccountController/Create
		public async Task<IActionResult> LogIn()
		{
			return View();
		}



		// POST: AccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogIn(string Email, string Password )
		{

			Result<AuthenticationResponse> result = new();
			try
			{
				result = await _accountService.LoginAsync(Email, Password);
				if (!result.IsSuccess)
				{
					ViewBag.ErrorMessage = result.Message;
					return View();
				}

				return RedirectToAction("Index", "Home");
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
					ViewBag.ErrorMessage = result.Message;
					return View();
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	

	}
}
