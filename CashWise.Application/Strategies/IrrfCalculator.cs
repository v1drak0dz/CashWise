using CashWise.Application.Strategies.Interfaces;
using CashWise.Application.Strategies.IrrfRanges;

namespace CashWise.Application.Strategies
{
    public class IrrfCalculator
    {
        private readonly List<(decimal limit, Type strategyType)> _grades;
        private const decimal FreeRangeLimit = 2428.80m;
        private const decimal FirstRangeLimit = 2726.65m;
        private const decimal SecondRangeLimit = 3751.05m;
        private const decimal ThirdRangeLimit = 4664.68m;

        public IrrfCalculator()
        {
            _grades = new List<(decimal, Type)>
            {
                (FirstRangeLimit, typeof(FirstRange)),
                (SecondRangeLimit, typeof(SecondRange)),
                (ThirdRangeLimit, typeof(ThirdRange)),
            };
        }

        public decimal Calculate(decimal salary)
        {
            if (salary <= FreeRangeLimit)
                return salary;

            foreach (var grade in _grades)
            {
                if (salary <= grade.limit)
                {
                    ITaxStrategy strategy = (ITaxStrategy)Activator.CreateInstance(grade.strategyType)!;
                    return strategy.Calculate(salary);
                };
            }

            return new FourthRange().Calculate(salary);
        }
    }
}
