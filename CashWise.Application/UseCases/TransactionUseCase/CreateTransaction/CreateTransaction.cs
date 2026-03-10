using CashWise.Domain.Repositories;
using CashWise.Domain.Entities;

using FluentValidation;

namespace CashWise.Application.UseCases.TransactionUseCase.CreateTransaction
{
    public class CreateTransaction : ICreateTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
            return transaction;
        }
    }
}
