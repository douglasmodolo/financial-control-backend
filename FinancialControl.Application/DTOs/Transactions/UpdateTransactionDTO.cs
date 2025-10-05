using FinancialControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.Application.DTOs.Transactions
{
    public class UpdateTransactionDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
