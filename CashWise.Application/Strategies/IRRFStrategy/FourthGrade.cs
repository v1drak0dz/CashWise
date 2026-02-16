namespace CashWise.Application.Strategies.IRRFStrategy
{
    public class FourthGrade
    {
        private const decimal Deduction = 908.73m;
        private const decimal Percentage = .275m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
