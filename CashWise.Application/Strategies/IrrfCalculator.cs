using CashWise.Application.Attributes;
using CashWise.Application.Strategies.Interfaces;
using CashWise.Application.Strategies.IrrfRanges;
using System.Reflection;

namespace CashWise.Application.Strategies
{
    public class IrrfCalculator
    {
        private readonly List<(decimal limit, Type strategyType)> _grades;
        private const decimal FreeRangeLimit = 2428.80m;

        public IrrfCalculator()
        {
            _grades = new List<(decimal, Type)>
            {
                (TryGetDecimalRange(typeof(FirstRange)), typeof(FirstRange)),
                (TryGetDecimalRange(typeof(SecondRange)), typeof(SecondRange)),
                (TryGetDecimalRange(typeof(ThirdRange)), typeof(ThirdRange)),
            };
        }

        public decimal Calculate(decimal salary)
        {
            if (salary <= FreeRangeLimit)
                return salary;

            foreach (var (limit, strategyType) in _grades)
            {
                if (salary <= limit)
                {
                    ITaxStrategy strategy = (ITaxStrategy)Activator.CreateInstance(strategyType)!;
                    return strategy.Calculate(salary);
                };
            }

            return new FourthRange().Calculate(salary);
        }

        private decimal TryGetDecimalRange(Type strategyType)
        {
            var strategy = strategyType.GetCustomAttribute<RangeAttribute>();

            if (strategy == null)
                throw new InvalidOperationException($"RangeAttribute not found for {strategyType.Name}");

            return strategy.MaxRange;
        }
    }
}
