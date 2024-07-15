
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

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "Home");
				}

				if (TempData[MessageType.MessageError.ToString()] != null)
				{
					ViewBag.MessageError = TempData[MessageType.MessageError.ToString()];
				}
				if (TempData[MessageType.MessageSuccess.ToString()] != null)
				{
					ViewBag.MessageSuccess = TempData[MessageType.MessageSuccess.ToString()];
				}


				return View(result.Data);
			}
			catch
			{
				throw;
			}

		}

		// GET: UserController/Create
		public async Task<IActionResult> HandelUserActivationState(string name, string id, UserActivationStateOperation operation)
		{
			ViewBag.Operation = operation;
			ViewBag.id = id;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> HandelUserActivationState(string id, UserActivationStateOperation operation)
		{
			Result<UserModel> result = new();
			try
			{
				if (operation == UserActivationStateOperation.Activate)
				{
					result = await _userService.ActivateAsync(id);
				}
				if (operation == UserActivationStateOperation.Deactivate)
				{
					result = await _userService.DeActivateAsync(id);
				}

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "User");
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;

				return RedirectToAction("Index", "User");
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
			
					TempData[MessageType.MessageError.ToString()] = result.Message;
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
					TempData[MessageType.MessageError.ToString()] = result.Message;
					resultInner = await _userService.GetByIdAsync(saveModel.Id);
					return View(resultInner.Data);
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return View("Index");
			}
			catch
			{
				throw;
			}
		}


	}
}
