using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class CreditCardController : Controller
	{
		private readonly ICreditCardService _creditCardService;

		public CreditCardController(ICreditCardService creditCardService)
		{
			_creditCardService = creditCardService;
		}
		// GET: CreditCardController
		public ActionResult Index()
		{
			return View();
		}

		// GET: CreditCardController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CreditCardController/Create
		public async Task<IActionResult> Create()
		{
			return View();
		}

		// POST: CreditCardController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SaveCreditCardModel saveModel)
		{
			Result<SaveCreditCardModel> result = new();
			try
			{
				result = await _creditCardService.SaveAsync(saveModel);

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

		// GET: CreditCardController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			Result<CreditCardModel> result = new();
			try
			{
				result = await _creditCardService.GetByIdAsync(id);

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

		// POST: CreditCardController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Guid id, IFormCollection collection)
		{
			Result<bool> result = new();
			try
			{
				result = await _creditCardService.DeleteAsync(id);
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
