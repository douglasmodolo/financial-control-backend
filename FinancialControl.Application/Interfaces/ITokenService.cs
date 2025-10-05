using FinancialControl.Domain.Entities;

namespace FinancialControl.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
