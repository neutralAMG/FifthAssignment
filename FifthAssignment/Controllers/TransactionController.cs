using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Middelware.Filters;
using FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FifthAssignment.Presentation.WebApp.Controllers
{
	[ServiceFilter(typeof(UserIsLogIn))]
	[ServiceFilter(typeof(IsUserActive))]
	[Authorize(Roles ="client")]
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
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
		public ActionResult Index()
		{

			return View();
		}


		// GET: TransactionController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
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
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
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
					ViewBag.MessageError = result.Message;
					return View("Index");

				}

				ViewBag.MessageSuccess = result.Message;

                return View("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: TransactionController/Edit/5
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> ConfirmTransaction(SaveBasePaymentDto saveModel)
		{
			return View(saveModel);
		}

		// POST: TransactionController/Edit/5
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ValidateTransaction(SaveBasePaymentDto saveModel)
		{
			Result<bool> result = new();
			try
			{
             
                if (saveModel.Emisor == default)
				{
					ViewBag.MessageError = "The emisor fild can not be empty";
                    return View("Index");
                }

                if (saveModel.Receiver == default)
                {
					ViewBag.MessageError = "The reciver fild can not be empty";
                    return View("Index");
                }
                if (saveModel.Amount == default)
                {
                    ViewBag.MessageError = "The amount fild can not be empty";
                    return View("Index");
                }   
				
				if (saveModel.Emisor == saveModel.Receiver)
                {
                    ViewBag.MessageError = "The emisor cant make a transaction to itself";
                    return View("Index");
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.MessageError = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                    return View("Index");
                }
                result = await _transactionStrategy.MakeValidation(saveModel);

				if (!result.IsSuccess)
				{
					ViewBag.MessageError = result.Message;
					return View("Index");

				}
				ViewBag.MessageSuccess = result.Message;

                return View("ConfirmTransaction", saveModel);
			}
			catch
			{
				return View();
			}
		}

	}
}
