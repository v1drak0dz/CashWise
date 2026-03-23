using CashWise.Domain.Entities;
using CashWise.Domain.Enums;
using CashWise.Domain.ValueObject;
using System.Text.RegularExpressions;

namespace CashWise.Application.UseCases.RecurringExpenses
{
    public class RecurringExpenseDetector : IRecurringExpenseDetector
    {
        public List<RecurringExpense> Detect(List<Transaction> transactions)
        {
            var recurringExpenses = new List<RecurringExpense>();

            var transactionGroups = new Dictionary<string, List<Transaction>>();

            foreach (var transaction in transactions)
            {
                if (transaction.TransactionType != TransactionType.Expense)
                    continue;

                var key = Normalize(transaction.Description);

                if (!transactionGroups.ContainsKey(key))
                    transactionGroups[key] = new List<Transaction>();

                transactionGroups[key].Add(transaction);
            }

            foreach (var group in transactionGroups)
            {
                var groupValue = group.Value;

                if (groupValue.Count < 3) continue;

                var orderedTransactions = SortByDate(groupValue);

                var transactionIntervals = CalculateIntervals(orderedTransactions);
                var expenseFrequency = DetectFrequency(transactionIntervals);
                var recurringConfidence = CalculateConfidence(transactionIntervals);

                if (recurringConfidence >= .7)
                    recurringExpenses.Add(new RecurringExpense(group.Key, expenseFrequency, recurringConfidence));
            }

            return recurringExpenses;
        }

        private List<Transaction> SortByDate(List<Transaction> transactions)
        {
            for (var i = 1; i < transactions.Count; i++)
            {
                var currentTransaction = transactions[i];
                var j = i - 1;

                while (j >= 0 && transactions[j].Date > currentTransaction.Date)
                {
                    transactions[j + 1] = transactions[j];
                    j--;
                }

                transactions[j + 1] = currentTransaction;
            }

            return transactions;
        }

        private List<int> CalculateIntervals(List<Transaction> transactions)
        {
            var intervals = new List<int>();

            for (int i = 1; i < transactions.Count; i++)
                intervals.Add((transactions[i].Date - transactions[i - 1].Date).Days);

            return intervals;
        }

        private double CalculateConfidence(List<int> intervals)
        {
            var average = intervals.Average();
            var variance = intervals.Average(i => Math.Pow(i - average, 2));
            var standardDeviation = Math.Sqrt(variance);

            return 1 / (1 + standardDeviation);
        }

        private FrequencyType DetectFrequency(List<int> intervals)
        {
            var average = intervals.Average();

            if (Math.Abs(average - 7) <= 2) return FrequencyType.Weekly;
            if (Math.Abs(average - 30) <= 5) return FrequencyType.Monthly;
            if (Math.Abs(average - 365) <= 20) return FrequencyType.Yearly;

            return FrequencyType.Unknown;
        }

        private string Normalize(string description)
        {
            var cleaned = description.ToLower();

            cleaned = Regex.Replace(cleaned, @"[^a-z0-9\s]", " ");
            cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

            return cleaned.Split(' ')[0];
        }
    }
}
