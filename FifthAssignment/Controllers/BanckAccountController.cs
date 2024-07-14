using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class BanckAccountController : Controller
	{
		private readonly IBankAccountService bankAccountService;

		public BanckAccountController(IBankAccountService bankAccountService)
        {
			this.bankAccountService = bankAccountService;
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
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BanckAccountController/Delete/5
		public async Task<IActionResult> DeleteBankAccount(Guid id)
		{
			return View();
		}

		// POST: BanckAccountController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteBankAccount(Guid id, IFormCollection collection)
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
