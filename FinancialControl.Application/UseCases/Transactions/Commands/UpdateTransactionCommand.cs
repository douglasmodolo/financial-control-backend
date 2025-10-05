using FinancialControl.Domain.Enums;
using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Commands
{
    public class UpdateTransactionCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}
