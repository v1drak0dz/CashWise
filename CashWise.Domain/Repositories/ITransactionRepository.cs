using CashWise.Domain.Entities;

namespace CashWise.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(int id);
        Task<List<Transaction>> GetAllAsync();
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int id);
    }
}
