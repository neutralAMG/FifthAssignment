

using System.ComponentModel.DataAnnotations;

namespace FifthAssignment.Core.Application.Core
{
	public class GetBasePaymentDto
	{
		public Guid Id { get; set; }
		public Guid Emisor { get; set; }
		public Guid Receiver { get; set; }
		public decimal Amount { get; set; }
	}
	public class SaveBasePaymentDto
	{
		public Guid Id { get; set; }
        [Required(ErrorMessage = "Transaction emisor is a requiered fild")]
        public Guid Emisor { get; set; }
        [Required(ErrorMessage = "Transaction emisor is a requiered fild")]
        public Guid Receiver { get; set; }
        [Required(ErrorMessage = "Transaction emisor is a requiered fild")]
        public decimal Amount { get; set; }
		public int TransactionType { get; set; }
	}
}
