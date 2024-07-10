

using FifthAssignment.Core.Application.Core;

namespace FifthAssignment.Core.Application.Interfaces
{
	public interface IPay
	{
		Task<Result<SaveBasePaymentDto>> Pay(SaveBasePaymentDto paymentDto);
		Task<Result<bool>> ValidatePayment(SaveBasePaymentDto paymentDto);
	}
}
