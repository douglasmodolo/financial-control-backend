using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUserService _loggedUserService;

        public CreateTransactionCommandHandler(IGenericRepository<Transaction> transactionRepository, IUnitOfWork unitOfWork, ILoggedUserService loggedUserService)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _loggedUserService = loggedUserService;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();

            var transaction = new Transaction(
                request.Title,
                request.Amount,
                request.Type,
                request.CategoryId,
                userId);

            await _transactionRepository.AddAsync(transaction);

            await _unitOfWork.CommitAsync();

            return transaction.Id;
        }
    }
}
