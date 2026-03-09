using CashWise.Application.Strategies.Interfaces;

namespace CashWise.Application.Strategies.IrrfRanges
{
    public class ThirdRange : ITaxStrategy
    {
        private const decimal Deduction = 675.49m;
        private const decimal Percentage = .225m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
