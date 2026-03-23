using CashWise.Domain.Enums;

namespace CashWise.Domain.ValueObject
{
    public class RecurringExpense
    {
        public string Description { get;}
        public FrequencyType Frequency { get; }
        public double Confidence { get; }

        public RecurringExpense(string description, FrequencyType frequency, double confidence)
        {
            Description = description;
            Frequency = frequency;
            Confidence = confidence;
        }
    }
}
