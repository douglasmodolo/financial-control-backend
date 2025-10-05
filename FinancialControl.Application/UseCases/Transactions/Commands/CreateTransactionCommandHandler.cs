using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransactionCommandHandler(IGenericRepository<Transaction> transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction(
                request.Title,
                request.Amount,
                request.Type,
                request.CategoryId,
                request.UserId);

            await _transactionRepository.AddAsync(transaction);

            await _unitOfWork.CommitAsync();

            return transaction.Id;
        }
    }
}
