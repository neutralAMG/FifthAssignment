

namespace FifthAssignment.Core.Application.Models.LoanModels
{
	public class LoanModel
	{
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public string IdentifierNumber { get; set; }
		public string UserId { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
