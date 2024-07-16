using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			Dictionary<int, List<SelectListItem>> list = GetSelectLists(type);
			ViewBag.Emisor = list[1];
			ViewBag.Receiver = list[2];
			return View(new SaveBasePaymentDto { TransactionType = (int)type });
		}

		private Dictionary<int, List<SelectListItem>> GetSelectLists(TransactionTypes type)
		{
			Dictionary<int, List<SelectListItem>> selectList = new();
			if (type == TransactionTypes.ExpressPayment)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());
			}
			if (type == TransactionTypes.CreditCardPayment)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserCreditCardSelectList());
			}
			if (type == TransactionTypes.LoanPayment)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserLoanSelectList());
			}
			if (type == TransactionTypes.BeneficiaryPayment)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserBeneficiarySelectList());
			}
			if (type == TransactionTypes.MoneyAdvance)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserCreditCardSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());

			}
			if (type == TransactionTypes.Transfer)
			{
				selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
				selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());
			}
			return selectList;
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
		public async Task<IActionResult> ConfirmTransaction(SaveBasePaymentDto saveModel)
		{
			return View(saveModel);
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
				return View("ConfirmTransaction", saveModel);
			}
			catch
			{
				return View();
			}
		}

	}
}
