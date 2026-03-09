using CashWise.Application.Strategies.Interfaces;

namespace CashWise.Application.Strategies.IrrfRanges
{
    public class FourthRange : ITaxStrategy
    {
        private const decimal Deduction = 908.73m;
        private const decimal Percentage = .275m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
