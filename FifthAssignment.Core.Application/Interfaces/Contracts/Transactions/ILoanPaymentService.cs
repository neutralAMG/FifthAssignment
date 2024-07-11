using FifthAssignment.Core.Application.Core;
using FifthAssignment.Core.Domain.Entities.PaymentContext;

namespace FifthAssignment.Core.Application.Interfaces.Contracts.Transactions
{
    public interface ILoanPaymentService : IBasePaymentService<LoanPayment>, ITransaction
    {
    }
}
