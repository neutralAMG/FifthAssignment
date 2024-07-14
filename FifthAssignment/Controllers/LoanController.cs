using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Application.Services.CoreServices;
using FifthAssignment.Presentation.WebApp.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class LoanController : Controller
	{
		private readonly ILoanService _loanService;

		public LoanController(ILoanService loanService)
        {
			_loanService = loanService;
		}

		// GET: LoanController/Create
		public async Task<IActionResult> CreateLoan()
		{
			return View();
		}

		// POST: LoanController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateLoan(SaveLoanModel saveModel)
		{
			Result<SaveLoanModel> result = new();
			try
			{
				result = await _loanService.SaveAsync(saveModel);

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

		// GET: LoanController/Delete/5
		public async Task<IActionResult> DeleteLoan(Guid id)
		{
			Result<LoanModel> result = new();
			try
			{
				result = await _loanService.GetByIdAsync(id);

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

		// POST: LoanController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteLoan(Guid id, IFormCollection collection)
		{
			Result<bool> result = new();
			try
			{
				result = await _loanService.DeleteAsync(id);
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
