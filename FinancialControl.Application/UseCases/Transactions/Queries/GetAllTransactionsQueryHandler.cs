using FinancialControl.Application.Interfaces;
using FinancialControl.Application.ViewModels.Transactions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Application.UseCases.Transactions.Queries
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggedUserService _loggedUserService;

        public GetAllTransactionsQueryHandler(IApplicationDbContext context, ILoggedUserService loggedUserService)
        {
            _context = context;
            _loggedUserService = loggedUserService;
        }

        public async Task<IEnumerable<TransactionViewModel>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();

            var transactions = await _context.Transactions
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Amount = t.Amount,
                    Type = t.Type,
                    CategoryName = t.Category.Name,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync(cancellationToken);

            return transactions;
        }
    }
}
