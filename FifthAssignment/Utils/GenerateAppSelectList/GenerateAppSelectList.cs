using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using FifthAssignment.Core.Application.Interfaces.Contracts.User;
using FifthAssignment.Core.Application.Models.BankAccountsModels;
using FifthAssignment.Core.Application.Models.BeneficiaryModels;
using FifthAssignment.Core.Application.Models.CreditCardModels;
using FifthAssignment.Core.Application.Models.LoanModels;
using FifthAssignment.Core.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList
{
    public class GenerateAppSelectList : IGenerateAppSelectList
    {
        private readonly IUserService _userService;
        private readonly IBeneficiaryService _beneficiaryService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ICreditCardService _creditCardService;
        private readonly ILoanService _loanService;

        public GenerateAppSelectList(IUserService userService, IBeneficiaryService beneficiaryService, IBankAccountService bankAccountService, ICreditCardService creditCardService, ILoanService loanService)
        {
            _userService = userService;
            _beneficiaryService = beneficiaryService;
            _bankAccountService = bankAccountService;
            _creditCardService = creditCardService;
            _loanService = loanService;
        }
        public List<SelectListItem> GenerateUserBankAccountSelectList()
        {
            List<BankAccountModel> BankAccounts = _bankAccountService.GetAllWithCurrentUserIdAsync().Result.Data;

            return BankAccounts.Select(b => new SelectListItem
            {
                Selected = false,
                Text = b.IdentifierNumber,
                Value = b.Id.ToString(),
            }).ToList();
        }

        public List<SelectListItem> GenerateUserBeneficiarySelectList()
        {
            List<BeneficiaryModel> beneficiaries = _beneficiaryService.GetAllWithCurrentUserIdAsync().Result.Data;

            return beneficiaries.Select(b => {
                var userBeneficiary = _userService.GetUserBeneficiarieAsync(b.UserBeneficiaryBankAccount.UserId).Result.Data;
                return new SelectListItem
                {

                    Selected = false,
                    Text = userBeneficiary.FirstName + " " + userBeneficiary.LastName,
                    Value = b.UserBeneficiaryBankAccountId.ToString()
                };
                
                }).ToList();
        }

        public List<SelectListItem> GenerateUserCreditCardSelectList()
        {
            List<CreditCardModel> creditCards = _creditCardService.GetAllWithCurrentUserIdAsync().Result.Data;

            return creditCards.Select(c => new SelectListItem
            {

                Selected = false,
                Text = c.IdentifierNumber,
                Value = c.Id.ToString(),

            }).ToList();
        }

        public List<SelectListItem> GenerateUserLoanSelectList()
        {
            List<LoanModel> loans = _loanService.GetAllWithCurrentUserIdAsync().Result.Data;

            return loans.Select(l => new SelectListItem
            {
                Selected = false,
                Text = l.IdentifierNumber,
                Value = l.Id.ToString(),
            }).ToList();
        }

        public List<SelectListItem> GenerateUserRolesSelectList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Admin",
                    Value = 1.ToString(),
                },
                new SelectListItem{
                Text = "Client",
                Value = 2.ToString(),
                }

            };
        }
    }
}
