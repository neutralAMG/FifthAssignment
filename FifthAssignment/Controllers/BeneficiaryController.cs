using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	[Authorize(Roles = "client")]
	public class BeneficiaryController : Controller
	{
		private readonly IBeneficiaryService _beneficiaryService;

		public BeneficiaryController(IBeneficiaryService beneficiaryService)
        {
			_beneficiaryService = beneficiaryService;
		}
        // GET: BeneficiaryController
        public async Task<IActionResult> Index()
		{
			Result<List<BeneficiaryModel>> result = new();
			try
			{
				result = await _beneficiaryService.GetAllAsync();

				if (!result.IsSuccess)
				{
					ViewBag.Message = result.Data;
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "Home");
				}

				if (TempData[MessageType.MessageError.ToString()] != null)
				{
					ViewBag[MessageType.MessageError.ToString()] = TempData[MessageType.MessageError.ToString()];
				}

				if (TempData[MessageType.MessageSuccess.ToString()] != null)
				{
					ViewBag[MessageType.MessageSuccess.ToString()] = TempData[MessageType.MessageSuccess.ToString()];
				}

				return View(result.Data);
			}
			catch
			{
				throw;
			}
		}

		// GET: BeneficiaryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BeneficiaryController/Create
		public async Task<IActionResult> CreateBeneficiary(string identifierNumber)
		{
			return View();
		}

		// POST: BeneficiaryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateBeneficiary(SaveBeneficiaryModel saveModel)
		{
			Result<SaveBeneficiaryModel> result = new();
			try
			{
				result = await _beneficiaryService.SaveAsync(saveModel);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index");
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return RedirectToAction("Index");
			}
			catch
			{
				throw;
			}
		}

		// GET: BeneficiaryController/Delete/5
		public async Task<IActionResult> DeleteBeneficiary(Guid id)
		{
			Result<BeneficiaryModel> result = new();
			try
			{
				result = await _beneficiaryService.GetByIdAsync(id);
				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index");

				}
				return View(result.Data);
			}
			catch
			{
				throw;
			}
		}

		// POST: BeneficiaryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteBeneficiary(Guid id, IFormCollection collection)
		{
			Result<bool> result = new();
			try
			{
				result = await _beneficiaryService.DeleteAsync(id);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index");
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
