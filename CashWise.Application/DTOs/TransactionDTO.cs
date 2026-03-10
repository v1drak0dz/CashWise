using CashWise.Domain.Enums;

namespace CashWise.Application.DTOs
{
    public class TransactionRequestDTO
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public class TransactionResponseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
