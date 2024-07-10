

namespace FifthAssignment.Core.Application.Core
{
	public class GetBasePaymentDto
	{
		public Guid Id { get; set; }
		public string Emisor { get; set; }
		public string Receiver { get; set; }
		public double Amount { get; set; }
	}
	public class SaveBasePaymentDto
	{
		public Guid Id { get; set; }
		public string Emisor { get; set; }
		public string Receiver { get; set; }
		public double Amount { get; set; }
	}
}
