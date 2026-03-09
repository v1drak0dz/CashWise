using CashWise.Domain.Repositories;
using CashWise.Domain.Entities;

using FluentValidation;

namespace CashWise.Application.UseCases.TransactionUseCase.CreateTransaction
{
    public class CreateTransaction : ICreateTransaction
    {
        private readonly ITransactionRepository _transactionRepository;
        private IValidator<Transaction> _transactionValidator;

        public CreateTransaction(ITransactionRepository transactionRepository, IValidator<Transaction> transactionValidator)
        {
            _transactionRepository = transactionRepository;
            _transactionValidator = transactionValidator;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            var validatorResult = await _transactionValidator.ValidateAsync(transaction);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            await _transactionRepository.AddAsync(transaction);
            return transaction;
        }
    }
}
