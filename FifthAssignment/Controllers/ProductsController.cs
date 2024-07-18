using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Middelware.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FifthAssignment.Presentation.WebApp.Controllers
{

	public class ProductsController : Controller
	{
		private readonly ICreditCardService _creditCardService;
		private readonly IBankAccountService _bankAccountService;
		private readonly ILoanService _loanService;

		public ProductsController(ICreditCardService creditCardService, IBankAccountService bankAccountService, ILoanService loanService)
		{
			_creditCardService = creditCardService;
			_bankAccountService = bankAccountService;
			_loanService = loanService;
		}
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		// GET: ProductsController
		public async Task<IActionResult> Index(string id)
		{
			try
			{
				if (id == default)
				{
                    return RedirectToAction("Index", "User");
                }
				List<BaseProductModel> Products = new();
				Result<List<LoanModel>> userLoans = await _loanService.GetAllWithAnSpecificUserIdAsync(id);
				Result<List<BankAccountModel>> userBankAccount = await _bankAccountService.GetAllWithAnSpecificUserIdAsync(id);
				Result<List<CreditCardModel>> userCreditCard = await _creditCardService.GetAllWithAnSpecificUserIdAsync(id);

				userLoans.Data.ForEach(l => Products.Add(l));
				userBankAccount.Data.ForEach(b => Products.Add(b));
				userCreditCard.Data.ForEach(c => Products.Add(c));

				return View(Products);
			}
			catch
			{
                return RedirectToAction("Index", "User");
            }
		}
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		// GET: BanckAccountController/Create
		public async Task<IActionResult> CreateBankAccount(string userId)
		{

			return View(new SaveBankAccountModel { UserId = userId });
		}

		// POST: BanckAccountController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateBankAccount(SaveBankAccountModel saveModel)
		{
			Result<SaveBankAccountModel> result = new();
			try
			{
				result = await _bankAccountService.SaveAsync(saveModel);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", new { id = saveModel.UserId });
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return RedirectToAction("Index", new { id = saveModel.UserId });
			}
			catch
			{
                return RedirectToAction("Index", "User");
            }
		}
		// GET: LoanController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		public async Task<IActionResult> CreateLoan(string userId)
		{
			return View(new SaveLoanModel { UserId = userId });
		}

		// POST: LoanController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
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
					return RedirectToAction("Index", new { id = saveModel.UserId });
				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;
				return RedirectToAction("Index", new { id = saveModel.UserId });
			}
			catch
			{
                return RedirectToAction("Index", "User");
            }
		}

		// GET: CreditCardController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		public async Task<IActionResult> CreateCreditCard(string userId)
		{
			return View(new SaveCreditCardModel { UserId = userId });
		}

		// POST: CreditCardController/Create
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCreditCard(SaveCreditCardModel saveModel)
		{
			Result<SaveCreditCardModel> result = new();
			try
			{
				result = await _creditCardService.SaveAsync(saveModel);

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", new { id = saveModel.UserId });
				}
				TempData[MessageType.MessageSuccess.ToString()] = result.Message;

				return RedirectToAction("Index", new { id = saveModel.UserId });
			}
			catch
			{
                return RedirectToAction("Index", "User");
            }
		}


		// GET: CreditCardController/Delete/5
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		public async Task<IActionResult> DeleteProduct(string name, string userId, Guid id, ProductToDelete operation)
		{
			Result<CreditCardModel> result = new();
			try
			{

				ViewBag.Operation = operation;
				ViewBag.userId = userId;
				ViewBag.id = id;

				return View();
			}
			catch
			{
				return RedirectToAction("Index", "User");
			}

		}

		// POST: CreditCardController/Delete/5
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "Admim")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteProduct(string userId, Guid id, ProductToDelete operation)
		{
			Result<bool> result = new();
			try
			{
				if (operation == ProductToDelete.CreditCard)
				{
					result = await _creditCardService.DeleteAsync(id);
				}
				if (operation == ProductToDelete.BankAccount)
				{
					result = await _bankAccountService.DeleteAsync(id);
				}
				if (operation == ProductToDelete.Loan)
				{
					result = await _loanService.DeleteAsync(id);
				}

				if (!result.IsSuccess)
				{
					TempData[MessageType.MessageError.ToString()] = result.Message;
					return RedirectToAction("Index", "Products", new {id = userId });

				}

				TempData[MessageType.MessageSuccess.ToString()] = result.Message;

				return RedirectToAction("Index", "Products", new {id = userId });
			}
			catch
			{
				throw;
			}
		}

	}
}
