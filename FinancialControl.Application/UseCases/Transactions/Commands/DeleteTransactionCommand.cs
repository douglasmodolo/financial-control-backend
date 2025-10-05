using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Commands
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTransactionCommand(Guid id)
        {
            Id = id;
        }
    }
}
