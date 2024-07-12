

namespace FifthAssignment.Core.Application.Core
{
	public class GetBasePaymentDto
	{
		public Guid Id { get; set; }
		public Guid Emisor { get; set; }
		public Guid Receiver { get; set; }
		public double Amount { get; set; }
	}
	public class SaveBasePaymentDto
	{
		public Guid Id { get; set; }
		public Guid Emisor { get; set; }
		public Guid Receiver { get; set; }
		public double Amount { get; set; }
		public int TransactionType { get; set; }
	}
}
