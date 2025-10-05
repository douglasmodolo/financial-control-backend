using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Category> Categories { get; }
        DbSet<Transaction> Transactions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
