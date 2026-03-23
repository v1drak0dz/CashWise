using CashWise.Application.Strategies.Interfaces;
using CashWise.Application.Attributes;

namespace CashWise.Application.Strategies.IrrfRanges
{
    [Range(3751.05)]
    public class SecondRange : ITaxStrategy
    {
        private const decimal Deduction = 394.16m;
        private const decimal Percentage = .15m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
