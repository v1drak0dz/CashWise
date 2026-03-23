using CashWise.Domain.Entities;
using CashWise.Domain.ValueObject;

namespace CashWise.Application.UseCases.RecurringExpenses
{
    public interface IRecurringExpenseDetector
    {
        List<RecurringExpense> Detect(List<Transaction> transactions);
    }
}
