using CashWise.Application.Repositories.TransactionRepository;
using CashWise.Domain.Entities.Transaction;
using CashWise.Domain.Enums;
using CashWise.Domain.BusinessRules.StocksHandler;

namespace CashWise.Application.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private const string StockIncomeDescription = "Stock Income";

        private readonly ITransactionRepository _transactionRepository;
        private IStocksHandler _stocksHandler;

        public TransactionService(ITransactionRepository transactionRepository) =>
            _transactionRepository = transactionRepository;

        public async Task<Guid> CreateAsync(string description,
            decimal amount,
            TransactionCategory transactionCategory,
            TransactionType transactionType)
        {
            var transaction = new Transaction(description, amount, transactionCategory, transactionType);

            await _transactionRepository.AddAsync(transaction);
            return transaction.Id;
        }

        public async Task<ITransaction?> GetAsync(Guid id) =>
            await _transactionRepository.GetByIdAsync(id);

        public async Task<IEnumerable<ITransaction>> GetAllAsync() =>
            await _transactionRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id) =>
            await _transactionRepository.DeleteAsync(id);

        private async Task GenerateRevenueFromStock(Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                throw new Exception($"Could not find the transaction with id: {id}");

            var stockIncome = _stocksHandler.ApplyStockIncome(transaction.Amount);

            var newTransaction = new Transaction(StockIncomeDescription, stockIncome, TransactionCategory.Stocks,
                TransactionType.Revenue);

            await _transactionRepository.AddAsync(newTransaction);
        }

        private async Task SellStock(Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                throw new Exception($"Could not find the transaction with id: {id}");

            var netTransactionAmount = _stocksHandler.ProcessStockWithdraw(transaction.Amount);

            var newTransaction = new Transaction(transaction.Description, netTransactionAmount, transaction.Category, transaction.TransactionType);

            await _transactionRepository.AddAsync(newTransaction);
        }
}
}
