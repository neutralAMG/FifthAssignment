using Microsoft.AspNetCore.Mvc.Rendering;

namespace FifthAssignment.Presentation.WebApp.Utils.GenerateAppSelectList
{
	public interface IGenerateAppSelectList
	{
		List<SelectListItem> GenerateUserBankAccountSelectList();
		List<SelectListItem> GenerateUserBeneficiarySelectList();
		List<SelectListItem> GenerateUserCreditCardSelectList();
		List<SelectListItem> GenerateUserLoanSelectList();
	}
}
