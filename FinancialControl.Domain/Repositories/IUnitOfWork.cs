namespace FinancialControl.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
