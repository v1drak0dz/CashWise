namespace CashWise.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RangeAttribute : Attribute
    {
        public decimal MaxRange { get; }
        
        public RangeAttribute(double maxRange) =>
            MaxRange = (decimal)maxRange;
    }
}
