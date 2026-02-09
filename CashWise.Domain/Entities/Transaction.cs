using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities
{
    public sealed class Transaction
    {
        public int Id { get; }
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

            Description = description;
            Amount = amount;
            Category = category;
            TransactionType = transactionType;
        }
    }
}
