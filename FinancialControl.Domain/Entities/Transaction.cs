using FinancialControl.Domain.Common;
using FinancialControl.Domain.Enums;

namespace FinancialControl.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(string title, decimal amount, TransactionType type, Guid categoryId, Guid userId)
        {
            Title = title;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }

        public string Title { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }

        public Guid CategoryId { get; private set; }
        public Guid UserId { get; private set; }

        public Category Category { get; private set; }
        public User User { get; private set; }

        public void Update(string title, decimal amount, TransactionType type, Guid categoryId)
        {
            Title = title;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
