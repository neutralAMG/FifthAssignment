
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		// GET: UserController
		public async Task<IActionResult> Index()
		{
			Result<List<UserModel>> result = new();
			try
			{
				result = await _userService.GetAllAsync();

				return View(result.Data);
			}
			catch
			{
				throw;
			}

		}

		// GET: UserController/Create
		public async Task<IActionResult> HandelUserActivationState(int operation)
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> HandelUserActivationState(string id, int operation)
		{
			Result<UserModel> result = new();
			try
			{
				if (operation == (int)UserActivationStateOperation.Activate)
				{
					result = await _userService.ActivateAsync(id);
				}
				if (operation == (int)UserActivationStateOperation.Deactivate)
				{
					result = await _userService.DeActivateAsync(id);
				}

				if (!result.IsSuccess)
				{
					ViewBag.ErrorMessage = result.Message;
					return View("Index");
				}

				return View("Index");
			}
			catch
			{
				throw;
			}
		}
		// GET: UserController/Create
		public async Task<IActionResult> Create()
		{
			return View();
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Edit/5
		public async Task<IActionResult> EditUser(string id)
		{
			Result<UserModel> result = new();
			try
			{
				result = await _userService.GetByIdAsync(id);

				if (result.IsSuccess)
				{
					ViewBag.ErrorMessage = result.Message;

					return View("Index");
				}

				return View(result.Data);
			}
			catch
			{
				throw;
			}
		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditUser(SaveUserModel saveModel)
		{
			Result<SaveUserModel> result = new();

			try
			{
				Result<UserModel> resultInner = new();

				result = await _userService.UpdateAsync(saveModel);

				if (result.IsSuccess)
				{
					ViewBag.ErrorMessage = result.Message;
					resultInner = await _userService.GetByIdAsync(saveModel.Id);
					return View(resultInner.Data);
				}

				return View("Index");
			}
			catch
			{
				throw;
			}
		}

	
	}
}
