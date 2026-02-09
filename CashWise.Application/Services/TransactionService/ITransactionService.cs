using CashWise.Domain.Entities;
using CashWise.Domain.Enums;

namespace CashWise.Application.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<int> CreateAsync(string description,
                               decimal amount,
                               TransactionCategory transactionCategory,
                               TransactionType transactionType);
        Task<Transaction?> GetAsync(int id);
        Task<List<Transaction>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
