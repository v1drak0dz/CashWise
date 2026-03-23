using CashWise.Application.Attributes;
using CashWise.Application.Strategies.Interfaces;

namespace CashWise.Application.Strategies.IrrfRanges
{
    [Range(2726.65)]
    public class FirstRange : ITaxStrategy
    {
        private const decimal Deduction = 182.16m;
        private const decimal Percentage = .075m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
