
namespace FifthAssignment.Core.Application.Models
{
	public class HomeInformationGetModel
	{
		public int AmountOfTransactionAllTime { get; set; }
		public int AmountOfTransactionToday { get; set; }
		public int AmountOfPaymentsAllTime { get; set; }
		public int AmountOfPaymentsToday { get; set; }
		public int AmountOfProducts { get; set; }
		public int AmountOfActiveUsers { get; set; }
		public int AmountOfUnActive{ get; set; }
	}
}
