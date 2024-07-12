

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;

namespace FifthAssignment.Core.Application.Interfaces.Contracts.Transactions
{
	public interface ITransactioStrategy
	{
		Task<Result<SaveBasePaymentDto>> MakeTransaction(SaveBasePaymentDto saveBasePaymentDto);
		Task<Result<bool>> MakeValidation(SaveBasePaymentDto saveBasePaymentDto);
		
	}
}
