using CashWise.Domain.Entities;
using CashWise.Domain.Enums;

namespace CashWise.Application.Factories.TransactionFactory
{
    public class TransactionFactory
    {
        public Transaction Create(
            DateTime date,
            string description,
            decimal amount,
            TransactionCategory transactionCategory,
            TransactionType transactionType,
            bool executed
        )
        {
            return new Transaction(date, description, amount, transactionCategory, transactionType, executed);
        }
    }
}
