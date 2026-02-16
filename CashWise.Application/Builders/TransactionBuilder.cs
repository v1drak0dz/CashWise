using CashWise.Domain.Entities;
using CashWise.Domain.Enums;

namespace CashWise.Application.Builders
{
    public class TransactionBuilder
    {
        private DateTime _date = DateTime.Now;
        private string _description = "Transaction";
        private decimal _amount = 0m;
        private TransactionCategory _category = TransactionCategory.Others;
        private TransactionType _type = TransactionType.Expense;
        private bool _executed = true;

        public TransactionBuilder WithDate(DateTime date)
        {
            _date = date;
            return this;
        }

        public TransactionBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public TransactionBuilder WithAmount(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public TransactionBuilder WithCategory(TransactionCategory category)
        {
            _category = category;
            return this;
        }

        public TransactionBuilder WithType(TransactionType type)
        {
            _type = type;
            return this;
        }

        public TransactionBuilder WithExecuted(bool executed)
        {
            _executed = executed;
            return this;
        }

        public Transaction Build()
        {
            return Transaction.Create(_date,_description,_amount,_category,_type,_executed);
        }
    }
}
