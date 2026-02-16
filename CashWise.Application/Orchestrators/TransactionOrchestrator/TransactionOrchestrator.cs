using CashWise.Application.UseCases.TransactionUseCase.CreateTransaction;
using CashWise.Application.UseCases.TransactionUseCase.GetTransaction;
using CashWise.Domain.Entities;

namespace CashWise.Application.Orchestrator.TransactionOrchestrator
{
    public class TransactionOrchestrator : ITransactionOrchestrator
    {
        private readonly ICreateTransaction _createTransaction;
        private readonly IGetTransaction _getTransaction;

        public TransactionOrchestrator(ICreateTransaction createTransaction, IGetTransaction getTransaction)
        {
            _createTransaction = createTransaction;
            _getTransaction = getTransaction;
        }

        public Task<int> CreateTransactionAsync(Transaction transaction) => 
            _createTransaction.CreateTransactionAsync(transaction);

        public Task<Transaction?> GetTransactionByIdAsync(int id) =>
            _getTransaction.GetTransactionByIdAsync(id);

        public Task<IEnumerable<Transaction>> GetTransactionsAsync() =>
            _getTransaction.GetTransactionsAsync();
    }
}
