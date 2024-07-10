﻿

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Application.Dtos.Payments;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IBeneficiaryPaymentService : IBasePaymentService<BeneficiaryPayment>, IPay
	{
		
	}
}
