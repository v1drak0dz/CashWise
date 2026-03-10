using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities
{
    public sealed class Transaction
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionCategory TransactionCategory { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public bool Executed { get; private set; }

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
