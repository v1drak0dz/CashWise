using CashWise.Domain.Repositories;
using CashWise.Domain.Entities;
using CashWise.Application.Builders;

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

        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            var _transaction = new TransactionBuilder()
                .WithDescription(transaction.Description)
                .WithDate(transaction.Date)
                .WithType(transaction.TransactionType)
                .WithCategory(transaction.TransactionCategory)
                .WithAmount(transaction.Amount)
                .Build();

            var validatorResult = await _transactionValidator.ValidateAsync(_transaction);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            await _transactionRepository.AddAsync(_transaction);
            return _transaction.Id;
        }
    }
}
