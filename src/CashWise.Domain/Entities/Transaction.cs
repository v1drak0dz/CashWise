namespace CashWise.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; init; }
        public string Description { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public string Date { get; init; } = string.Empty;
        public string TransactionCategory { get; init; } = string.Empty;
        public string TransactionType { get; init; } = string.Empty;

        private Transaction() {}
        
        public Transaction(
            string description,
            decimal amount,
            string date,
            string transactionCategory,
            string transactionType
        )
        {
            if (decimal.IsNegative(amount))
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            if (string.IsNullOrWhiteSpace(description) || description.Trim().Length < 3)
                throw new ArgumentOutOfRangeException(nameof(description));
            
            Description = description;
            Amount = amount;
            Date = date;
            TransactionCategory = transactionCategory;
            TransactionType = transactionType;
        }
    }
}
