using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.LoanModels;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class LoanController : Controller
	{
		private readonly ILoanService _loanService;

		public LoanController(ILoanService loanService)
        {
			_loanService = loanService;
		}
        // GET: LoanController
        public ActionResult Index()
		{
			return View();
		}

		// GET: LoanController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: LoanController/Create
		public async Task<IActionResult> Create()
		{
			return View();
		}

		// POST: LoanController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SaveLoanModel collection)
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

		// GET: LoanController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			return View();
		}

		// POST: LoanController/Delete/5
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
