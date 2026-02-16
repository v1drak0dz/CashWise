using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;

namespace CashWise.Application.UseCases.TransactionUseCase.GetTransaction
{
    public class GetTransaction : IGetTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id) =>
            await _transactionRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync() =>
            await _transactionRepository.GetAllAsync();
    }
}
