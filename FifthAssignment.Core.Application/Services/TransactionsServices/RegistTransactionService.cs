
using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Application.Interfaces.Transactions;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Services.TransactionsServices
{
	public class RegistTransactionService : BasePaymentService<Transaction>, ITransactionService
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;
		private readonly ITransactionDetailRepository _transactionDetailRepository;

		public RegistTransactionService(ITransactionRepository  transactionRepository, IMapper mapper, ITransactionDetailRepository transactionDetailRepository) : base(transactionRepository, mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
			_transactionDetailRepository = transactionDetailRepository;
		}

		public async Task<Result<SavePaymentDto>> SaveAsync(SavePaymentDto entity)
		{
			Result<SavePaymentDto> result = new();
			try
			{
				Transaction entityToBeSave = _mapper.Map<Transaction>(entity);

				Transaction entitySaved = await _transactionRepository.SaveAsync(entityToBeSave);

				if (entitySaved == null)
				{
					result.IsSuccess = false;
					result.Message = "Error saving the payment";
					return result;
				}
				else
				{
					var saveTransactionDetail = await _transactionDetailRepository.SaveAsync(new TransactionDetail
					{

						PaymentId = result.Data.Id,

						TransactionTypeId = entity.TransactionTypeId,
						SpecificPaymentDetailId = entity.specificPaymentTosaveId
					});

					entitySaved.TransactionDetailId = saveTransactionDetail.Id;

					await _transactionRepository.UpdateAsync(entitySaved);
				}

				result.Data = _mapper.Map<SavePaymentDto>(entitySaved);

				result.Message = "payment was saved succesfuly";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Criitical error saving the payment";
				return result;
			}
		}

		public async Task<Result<bool>> UpdateAsync(SavePaymentDto saveDto)
		{
			Result<bool> result = new();
			try
			{
				Transaction transactionToBeUpdated = _mapper.Map<Transaction>(saveDto);

				var OperationResult = await _transactionRepository.UpdateAsync(transactionToBeUpdated);

				if (!OperationResult)
				{
					result.IsSuccess = false;
					result.Message = "Error updating the transaction log";
					return result;
				}
				result.Message = "transaction log updated succesfully";
				return result;
			}
			catch
			{
				result.IsSuccess = false;
				result.Message = "Critical while error updating the transaction log";
				return result;
			}
		}
	}
}
