using FinancialControl.Domain.Enums;

namespace FinancialControl.Application.DTOs.Transactions
{
    public class CreateTransactionDTO
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }
    }
}
