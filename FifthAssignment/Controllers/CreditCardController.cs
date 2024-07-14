using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models.CreditCardModels;
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
		public ActionResult Create()
		{
			return View();
		}

		// POST: CreditCardController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SaveCreditCardModel saveModel)
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

		// GET: CreditCardController/Delete/5
		public ActionResult Delete(Guid id)
		{
			return View();
		}

		// POST: CreditCardController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(Guid id, IFormCollection collection)
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
