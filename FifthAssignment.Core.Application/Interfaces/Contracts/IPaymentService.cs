﻿

using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts
{
	public interface IPaymentService : IBasePaymentService<Payment>, IPay
	{
	}
}
