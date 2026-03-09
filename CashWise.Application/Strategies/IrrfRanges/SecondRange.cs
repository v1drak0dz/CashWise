using CashWise.Application.Strategies.Interfaces;

namespace CashWise.Application.Strategies.IrrfRanges
{
    public class SecondRange : ITaxStrategy
    {
        private const decimal Deduction = 394.16m;
        private const decimal Percentage = .15m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
