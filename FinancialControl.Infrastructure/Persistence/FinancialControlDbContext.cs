using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialControl.Infrastructure.Persistence
{
    public class FinancialControlDbContext : DbContext, IApplicationDbContext
    {
        public FinancialControlDbContext(DbContextOptions<FinancialControlDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
