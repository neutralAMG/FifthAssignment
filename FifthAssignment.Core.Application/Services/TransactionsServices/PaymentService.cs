
using AutoMapper;
using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Services.TransactionsServices
{
	public class PaymentService : BasePaymentService<Payment>, IPaymentService
	{
		private readonly IPaymentRepository _paymentRepository;
		private readonly IMapper _mapper;

		public PaymentService(IPaymentRepository paymentRepository, IMapper mapper) : base(paymentRepository, mapper)
		{
			_paymentRepository = paymentRepository;
			_mapper = mapper;
		}

		public async Task<Result<SavePaymentDto>> SaveAsync(SavePaymentDto entity)
		{
			Result<SavePaymentDto> result = new();
			try
			{
				Payment entityToBeSave = _mapper.Map<Payment>(entity);

				Payment entitySaved = await _paymentRepository.SaveAsync(entityToBeSave);

				if (entitySaved == null)
				{
					result.IsSuccess = false;
					result.Message = "Error saving the payment";
					return result;
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
	}
}
