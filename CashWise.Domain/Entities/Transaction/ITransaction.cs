using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities.Transaction
{
    public interface ITransaction
    {
        public Guid Id { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public TransactionCategory Category { get; }
        public TransactionType TransactionType { get; }
    }
}
