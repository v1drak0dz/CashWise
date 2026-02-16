using CashWise.Domain.Entities;

namespace CashWise.Application.UseCases.TransactionUseCase.GetTransaction
{
    public interface IGetTransaction
    {
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
    }
}
