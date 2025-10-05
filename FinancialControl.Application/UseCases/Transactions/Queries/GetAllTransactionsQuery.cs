using FinancialControl.Application.ViewModels.Transactions;
using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Queries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionViewModel>>
    {
        public GetAllTransactionsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
