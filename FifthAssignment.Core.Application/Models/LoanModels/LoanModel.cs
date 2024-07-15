

namespace FifthAssignment.Core.Application.Models.LoanModels
{
	public class LoanModel : BaseProductModel
	{
        public LoanModel()
        {
            Type = "Loan";
        }
        public DateTime DateCreated { get; set; }
	}
}
