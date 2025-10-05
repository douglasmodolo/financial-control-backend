using FinancialControl.Domain.Enums;

namespace FinancialControl.Application.ViewModels.Transactions
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string CategoryName { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
