using CashWise.Domain.Entities;
using CashWise.Domain.Enums;

namespace CashWise.Application.Factories.TransactionFactory
{
    public interface ITransactionFactory
    {
        public Transaction Create(
            DateTime date,
            string description,
            decimal amount,
            TransactionCategory transactionCategory,
            TransactionType transactionType,
            bool executed
        );
    }
}
