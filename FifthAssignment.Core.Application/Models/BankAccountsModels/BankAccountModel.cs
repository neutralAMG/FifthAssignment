
namespace FifthAssignment.Core.Application.Models.BankAccountsModels
{
	public class BankAccountModel : BaseProductModel
	{
        public BankAccountModel()
        {
            Type = "Bank account";
        }
        public bool IsMain { get; set; }

	}
}
