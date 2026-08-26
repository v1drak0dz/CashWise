using CashWise.Domain.Entities;

namespace CashWise.Application.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task CreateTransactionAsync(Transaction transaction);
    }
}
