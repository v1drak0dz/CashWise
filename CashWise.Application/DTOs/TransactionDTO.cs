using CashWise.Domain.Enums;

namespace CashWise.Application.DTOs
{
    public record TransactionRequestDTO(
        string description,
        decimal amount,
        TransactionCategory transactionCategory,
        TransactionType transactionType
        );

    public record TransactionResponseDTO(
        int id,
        string description,
        decimal amount,
        TransactionCategory transactionCategory,
        TransactionType transactionType
        );
}
