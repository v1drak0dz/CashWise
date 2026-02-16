namespace CashWise.Application.Strategies.IRRFStrategy
{
    public class FirstGrade : IIRRFStrategy
    {
        private const decimal Deduction = 182.16m;
        private const decimal Percentage = .075m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
