

namespace FifthAssignment.Core.Application.Models
{
	public class BaseProductModel
	{
		public Guid Id { get; set; }	
		public string Type { get; set; }
		public string IdentifierNumber { get; set; }
		public string UserId { get; set; }
		public decimal Amount {  get; set; }
	}
}
