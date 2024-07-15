using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;
using Microsoft.AspNetCore.Mvc;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	public class TransactionController : Controller
	{
		private readonly ITransactionStrategy _transactionStrategy;
		private readonly IGenerateAppSelectList _generateAppSelectList;

		public TransactionController(ITransactionStrategy transactionStrategy, IGenerateAppSelectList generateAppSelectList)
        {
			_transactionStrategy = transactionStrategy;
			_generateAppSelectList = generateAppSelectList;
		}
        // GET: TransactionController
        public ActionResult Index()
		{
			if (TempData[MessageType.MessageError.ToString()] != null)
			{
				ViewBag.MessageError = TempData[MessageType.MessageError.ToString()].ToString();
			}
			if (TempData[MessageType.MessageSuccess.ToString()] != null)
			{
				ViewBag.MessageSuccess = TempData[MessageType.MessageSuccess.ToString()].ToString();
			}

			return View();
		}

	
		// GET: TransactionController/Create
		public async Task<IActionResult> MakeTransaction(TransactionTypes type)
		{
			return View(new SaveBasePaymentDto { TransactionType = (int)type });
		}

		// POST: TransactionController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MakeTransaction(SaveBasePaymentDto saveModel)
		{
			Result<SaveBasePaymentDto> result = new();
			try
			{
				result = await _transactionStrategy.MakeTransaction(saveModel);
				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return View(result);

				}
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: TransactionController/Edit/5
		public async Task<IActionResult> ConfirmTransaction()
		{
			return View();
		}

		// POST: TransactionController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ValidateTransaction(SaveBasePaymentDto saveModel)
		{
			Result<bool> result = new();
			try
			{
				result = await _transactionStrategy.MakeValidation(saveModel);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return View("Index");

				}
				return RedirectToAction("ConfirmTransaction", saveModel);
			}
			catch
			{
				return View();
			}
		}

	}
}
