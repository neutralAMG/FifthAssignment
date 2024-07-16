using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Models;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Models;
using FifthAssignment.Presentation.WebApp.Enums;
using FifthAssignment.Presentation.WebApp.Middelware.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FifthAssignment.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHomeService _homeService;
        private readonly ICreditCardService _creditCardService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ILoanService _loanService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, ICreditCardService creditCardService, IBankAccountService bankAccountService, ILoanService loanService)
		{
			_logger = logger;
			_homeService = homeService;
           _creditCardService = creditCardService;
           _bankAccountService = bankAccountService;
           _loanService = loanService;
        }

		public IActionResult Index()
		{
			if (TempData[MessageType.MessageError.ToString()] != null)
			{
				ViewBag[MessageType.MessageError.ToString()] = TempData[MessageType.MessageError.ToString()];
			}
			if (TempData[MessageType.MessageSuccess.ToString()] != null)
			{
				ViewBag[MessageType.MessageSuccess.ToString()] = TempData[MessageType.MessageSuccess.ToString()];
			}
			return View();
		}
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles ="Admim")]
		public async Task<IActionResult> AdminHomePage()
		{
			Result<HomeInformationGetModel> result = new();
			try
			{
				result = await _homeService.GetHomeInformationAsync();
				return View(result.Data);
			}
			catch
			{
				return View();
			}
		}
		[ServiceFilter(typeof(UserIsLogIn))]
		[ServiceFilter(typeof(IsUserActive))]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> ClientHomePage()
		{
            try
            {
                List<BaseProductModel> Products = new();
                Result<List<LoanModel>> userLoans = await _loanService.GetAllWithCurrentUserIdAsync();
                Result<List<BankAccountModel>> userBankAccount = await _bankAccountService.GetAllWithCurrentUserIdAsync();
                Result<List<CreditCardModel>> userCreditCard = await _creditCardService.GetAllWithCurrentUserIdAsync();

                userLoans.Data.ForEach(l => Products.Add(l));
                userBankAccount.Data.ForEach(b => Products.Add(b));
                userCreditCard.Data.ForEach(c => Products.Add(c));

                return View(Products);
            }
            catch
            {
                throw;
            }
          

		}
		public IActionResult UnActivateAccount()
		{
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
