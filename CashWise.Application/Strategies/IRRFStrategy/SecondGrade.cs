namespace CashWise.Application.Strategies.IRRFStrategy
{
    public class SecondGrade : IIRRFStrategy
    {
        private const decimal Deduction = 394.16m;
        private const decimal Percentage = .15m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
