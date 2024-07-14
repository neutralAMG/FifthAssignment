using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
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
			try
			{

			}
			catch
			{

			}
			return View();
		}

		// GET: BeneficiaryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BeneficiaryController/Create
		public async Task<IActionResult> Create()
		{
			return View();
		}

		// POST: BeneficiaryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SaveCreditCardModel saveModel)
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

		// GET: BeneficiaryController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			return View();
		}

		// POST: BeneficiaryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Guid id, IFormCollection collection)
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
	}
}
