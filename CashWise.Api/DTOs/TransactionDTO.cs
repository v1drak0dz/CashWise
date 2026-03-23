using CashWise.Domain.Enums;

namespace CashWise.Api.DTOs
{
    public class TransactionRequestDTO
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public class TransactionResponseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
