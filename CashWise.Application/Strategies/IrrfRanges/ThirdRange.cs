using CashWise.Application.Strategies.Interfaces;
using CashWise.Application.Attributes;

namespace CashWise.Application.Strategies.IrrfRanges
{
    [Range(4664.68)]
    public class ThirdRange : ITaxStrategy
    {
        private const decimal Deduction = 675.49m;
        private const decimal Percentage = .225m;

        public decimal Calculate(decimal salary) =>
            (salary * Percentage) - Deduction;
    }
}
