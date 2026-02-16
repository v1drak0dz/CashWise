using CashWise.Domain.Entities;

namespace CashWise.Application.Orchestrator.TransactionOrchestrator
{
    public interface ITransactionOrchestrator
    {
        Task<int> CreateTransactionAsync(Transaction transaction);
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
    }
}
