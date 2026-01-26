using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities.Transaction
{
    public sealed class Transaction : ITransaction
    {
        public Guid Id { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public TransactionCategory Category { get; }
        public TransactionType TransactionType { get; }

        public Transaction(string description,
                           decimal amount,
                           TransactionCategory category,
                           TransactionType transactionType)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("A description is required to insert the transaction!");

            if (decimal.IsNegative(amount))
                throw new ArgumentException("The amount can not be less than zero!");

            Id = Guid.NewGuid();
            Description = description;
            Amount = amount;
            Category = category;
            TransactionType = transactionType;
        }
    }
}
