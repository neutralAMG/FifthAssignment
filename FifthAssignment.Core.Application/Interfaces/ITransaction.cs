

using FifthAssignment.Core.Application.Core;

namespace FifthAssignment.Core.Application.Interfaces
{
	public interface ITransaction
	{
		Task<Result<SaveBasePaymentDto>>  MakeTransaction(SaveBasePaymentDto paymentDto);
		Task<Result<bool>> ValidateTransaction(SaveBasePaymentDto paymentDto);
	}
}
