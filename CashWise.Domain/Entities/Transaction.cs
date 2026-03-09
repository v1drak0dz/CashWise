using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities
{
    public sealed class Transaction
    {
        public int Id { get; }
        public DateTime Date { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public TransactionCategory TransactionCategory { get; }
        public TransactionType TransactionType { get; }
        public bool Executed { get; }

        public Transaction(
            DateTime date,
            string description,
            decimal amount,
            TransactionCategory transactionCategory,
            TransactionType transactionType,
            bool executed
            )
        {
            Date = date;
            Description = description;
            Amount = amount;
            TransactionCategory = transactionCategory;
            TransactionType = transactionType;
            Executed = executed;
        }
    }
}
