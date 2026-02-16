namespace CashWise.Application.Strategies.IRRFStrategy
{
    public class ThirdGrade : IIRRFStrategy
    {
        private const decimal Deduction = 675.49m;
        private const decimal Percentage = .225m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
