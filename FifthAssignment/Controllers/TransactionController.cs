using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Enums;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Transactions;
using FifthAssignment.Core.Application.Interfaces.Repositories;
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
    [Authorize(Roles = "client")]
    public class TransactionController : Controller
    {
        private readonly ITransactionStrategy _transactionStrategy;
        private readonly IGenerateAppSelectList _generateAppSelectList;
        private readonly IBankAccountService _bankAccountService;

        public TransactionController(ITransactionStrategy transactionStrategy, IGenerateAppSelectList generateAppSelectList, IBankAccountService bankAccountService)
        {
            _transactionStrategy = transactionStrategy;
            _generateAppSelectList = generateAppSelectList;
            _bankAccountService = bankAccountService;

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
            try
            {
                (Dictionary<int, List<SelectListItem>>, string) list = GetSelectLists(type);
                ViewBag.Emisor = list.Item1[1];
                ViewBag.Receiver = list.Item1[2];
                ViewBag.Name = list.Item2;
                return View(new SaveBasePaymentDto { TransactionType = (int)type });
            }
            catch
            {
                return View("Index");
            }

        }

        // GET: TransactionController/Create
        [ServiceFilter(typeof(UserIsLogIn))]
        [ServiceFilter(typeof(IsUserActive))]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> MakeExpressTransaction()
        {
            try
            {
                (Dictionary<int, List<SelectListItem>>, string) list = GetSelectLists(TransactionTypes.ExpressPayment);
                ViewBag.Emisor = list.Item1[1];
                ViewBag.Receiver = list.Item1[2];
                ViewBag.Name = list.Item2;
                return View(new SaveBasePaymentDto { TransactionType = (int)TransactionTypes.ExpressPayment });
            }
            catch
            {
                return View("Index");
            }

        }

        private (Dictionary<int, List<SelectListItem>>, string) GetSelectLists(TransactionTypes type)
        {
            Dictionary<int, List<SelectListItem>> selectList = new();
            string TransactionName = "";
            if (type == TransactionTypes.ExpressPayment)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());
                TransactionName = "Express payment";
            }
            if (type == TransactionTypes.CreditCardPayment)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserCreditCardSelectList());
                TransactionName = "Credit card payment";
            }
            if (type == TransactionTypes.LoanPayment)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserLoanSelectList());
                TransactionName = "Loan Payment";
            }
            if (type == TransactionTypes.BeneficiaryPayment)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserBeneficiarySelectList());
                TransactionName = "Beneficiary payment";
            }
            if (type == TransactionTypes.MoneyAdvance)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserCreditCardSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());
                TransactionName = "Money Advance";
            }
            if (type == TransactionTypes.Transfer)
            {
                selectList.Add(1, _generateAppSelectList.GenerateUserBankAccountSelectList());
                selectList.Add(2, _generateAppSelectList.GenerateUserBankAccountSelectList());
                TransactionName = "Transference";
            }
            return (selectList, TransactionName);
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
            try
            {
                if (saveModel.Emisor == default)
                {
                    return View("Index");
                }
                return View(saveModel);
            }
            catch
            {
                return View("Index");
            }

        }

        // POST: TransactionController/Edit/5
        [ServiceFilter(typeof(UserIsLogIn))]
        [ServiceFilter(typeof(IsUserActive))]
        [Authorize(Roles = "client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateTransaction(string numberIdentifier, SaveBasePaymentDto saveModel)
        {
            Result<bool> result = new();
            try
            {

                if (saveModel.Emisor == default)
                {
                    ViewBag.MessageError = "The emisor fild can not be empty";
                    return View("Index");
                }
                if (saveModel.TransactionType == (int)TransactionTypes.ExpressPayment)
                {
                    if (numberIdentifier == default)
                    {
                        ViewBag.MessageError = "The number Identifier fild can not be empty";
                        return View("Index");
                    }
                    var BankAccountResult = await _bankAccountService.GetByNumberIdentifierAsync(numberIdentifier);

                    if (!BankAccountResult.IsSuccess)
                    {

                        ViewBag.MessageError = "The is no account with that number identifier";
                        return View("Index");
                    }
                    saveModel.Receiver = BankAccountResult.Data.Id;

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

                //if (!ModelState.IsValid)
                //{
                //    ViewBag.MessageError = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                //    return View("Index");
                //}
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
