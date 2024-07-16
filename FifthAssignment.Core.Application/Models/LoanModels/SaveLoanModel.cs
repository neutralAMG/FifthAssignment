

namespace FifthAssignment.Core.Application.Models.LoanModels
{
	public class SaveLoanModel
	{
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
		public string IdentifierNumber { get; set; }
		public string UserId { get; set; }
		public DateTime DateCreated {  get; set; }
	}
}
