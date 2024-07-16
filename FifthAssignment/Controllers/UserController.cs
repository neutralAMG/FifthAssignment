
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.UserModel;
using FifthAssignment.Core.Application.Models.UserModels;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Middelware.Filters;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	[ServiceFilter(typeof(UserIsLogIn))]
	[ServiceFilter(typeof(IsUserActive))]
	[Authorize(Roles = "Admim")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
        private readonly IGenerateAppSelectList _generateAppSelectList;
	    
        public UserController(IUserService userService, IGenerateAppSelectList generateAppSelectList)
		{
			_userService = userService;
            _generateAppSelectList = generateAppSelectList;
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
					ViewBag.MessageError = TempData[MessageType.MessageError.ToString()].ToString();
				}
				if (TempData[MessageType.MessageSuccess.ToString()] != null)
				{
					ViewBag.MessageSuccess = TempData[MessageType.MessageSuccess.ToString()].ToString();
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

        // GET: UserController/Edit/5

        public async Task<IActionResult> EditUser(string id, bool IsAdmin)
		{
			Result<UserModel> result = new();
			try
			{
				result = await _userService.GetByIdAsync(id);

				if (!result.IsSuccess)
				{
			
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "User");
				}
				ViewBag.IsAdmin = IsAdmin;
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
		public async Task<IActionResult> EditUser(string OldPassword, string OldConfirmPassword, SaveUserModel saveModel)
		{
			Result<SaveUserModel> result = new();

			try
			{
				Result<UserModel> resultInner = await _userService.GetByIdAsync(saveModel.Id);

           ;

                if (saveModel.Password is null && saveModel.ComfirmPassword is null)
                {
                    saveModel.Password = OldPassword;
                    saveModel.ComfirmPassword = OldConfirmPassword;
                }
                else if (saveModel.Password != saveModel.ComfirmPassword)
                {
                    ViewBag.MessageError = "the passwords must match";
                    return RedirectToAction("EditUser", new { id = resultInner.Data.Id, IsAdmin = resultInner.Data.Roles.Contains("Admim") });
                }

                result = await _userService.UpdateAsync(saveModel);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("EditUser", new { id = resultInner.Data.Id, IsAdmin = resultInner.Data.Roles.Contains("Admim") });
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return RedirectToAction("Index");
			}
			catch
			{
				throw;
			}
		}


	}
}
