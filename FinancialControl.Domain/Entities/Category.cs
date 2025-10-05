using FinancialControl.Domain.Common;

namespace FinancialControl.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public string Name { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
