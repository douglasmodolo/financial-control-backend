using FinancialControl.Application.Exceptions;
using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Transactions.Commands
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUserService _loggedUserService;

        public UpdateTransactionCommandHandler(
            IGenericRepository<Transaction> transactionRepository,
            IUnitOfWork unitOfWork,
            ILoggedUserService loggedUserService)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _loggedUserService = loggedUserService;
        }

        public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);

            if (transaction is null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            if (transaction.UserId != userId)
            {
                throw new ForbiddenAccessException();
            }

            transaction.Update(request.Title, request.Amount, request.Type, request.CategoryId);
            await _unitOfWork.CommitAsync();
        }
    }
}
