using CashWise.Domain.Enums;

namespace CashWise.Api.WebApi.DTOs
{
    public record CreateTransactionDto(string description,
                                       decimal amount,
                                       TransactionCategory transactionCategory,
                                       TransactionType transactionType);

    public record UpdateTransactionDto(string description,
                                       decimal amount,
                                       TransactionCategory transactionCategory,
                                       TransactionType transactionType);

    public record TransactionResponseDto(int Id, 
                                     string description,
                                     decimal amount,
                                     TransactionCategory transactionCategory,
                                     TransactionType transactionType);

}
