using CashWise.Domain.Entities.Transaction;
using CashWise.Domain.Enums;

namespace CashWise.Application.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<Guid> CreateAsync(string description,
                               decimal amount,
                               TransactionCategory transactionCategory,
                               TransactionType transactionType);
        Task<ITransaction?> GetAsync(Guid id);
        Task<IEnumerable<ITransaction>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
