using FinancialControl.Domain.Repositories;
using FinancialControl.Infrastructure.Persistence;

namespace FinancialControl.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialControlDbContext _context;

        public UnitOfWork(FinancialControlDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
