using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class BanckAccountController : Controller
	{
		private readonly IBankAccountService _bankAccountService;

		public BanckAccountController(IBankAccountService bankAccountService)
		{
			_bankAccountService = bankAccountService;
		}
		// GET: BanckAccountController
		public ActionResult Index()
		{
			return View();
		}

		// GET: BanckAccountController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BanckAccountController/Create
		public async Task<IActionResult> CreateBankAccount()
		{
			return View();
		}

		// POST: BanckAccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateBankAccount(SaveBankAccountModel saveModel)
		{
			Result<SaveBankAccountModel> result = new();
			try
			{
				result = await _bankAccountService.SaveAsync(saveModel);

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
				return View();
			}
		}

		// GET: BanckAccountController/Delete/5
		public async Task<IActionResult> DeleteBankAccount(Guid id)
		{
			Result<BankAccountModel> result = new();
			try
			{
				result = await _bankAccountService.GetByIdAsync(id);
				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "User");

				}
				return View(result.Data);
			}
			catch
			{
				throw;
			}
			
		}

		// POST: BanckAccountController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteBankAccount(Guid id, IFormCollection collection)
		{
			Result<bool> result = new();
			try
			{
				result = await _bankAccountService.DeleteAsync(id);
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
	}
}
