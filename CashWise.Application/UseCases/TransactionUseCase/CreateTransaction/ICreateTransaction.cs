using CashWise.Domain.Entities;

namespace CashWise.Application.UseCases.TransactionUseCase.CreateTransaction
{
    public interface ICreateTransaction
    {
        Task<int> CreateTransactionAsync(Transaction transaction);
    }
}
