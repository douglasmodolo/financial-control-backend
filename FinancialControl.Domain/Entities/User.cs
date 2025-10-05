using FinancialControl.Domain.Common;

namespace FinancialControl.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string? PasswordHash { get; private set; } // Pode ser nulo se usar login social

        public ICollection<Category> Categories { get; private set; } = new List<Category>();
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
    }
}
