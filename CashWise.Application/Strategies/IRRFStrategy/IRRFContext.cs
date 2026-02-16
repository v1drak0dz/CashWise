namespace CashWise.Application.Strategies.IRRFStrategy
{
    public class IRRFContext
    {
        private readonly List<(decimal limit, IIRRFStrategy strategy)> _grades;
        private const decimal FreeGradeLimit = 2428.80m;
        private const decimal FirstGradeLimit = 2726.65m;
        private const decimal SecondGradeLimit = 3751.05m;
        private const decimal ThirdGradeLimit = 4664.68m;

        public IRRFContext()
        {
            _grades = new List<(decimal, IIRRFStrategy)>
            {
                (FreeGradeLimit, new FreeGrade()),
                (FirstGradeLimit, new FirstGrade()),
                (SecondGradeLimit, new SecondGrade()),
                (ThirdGradeLimit, new ThirdGrade()),
            };
        }

        public decimal Calculate(decimal salary)
        {
            foreach (var grade in _grades)
            {
                if (salary <= grade.limit)
                    return grade.strategy.Calculate(salary);
            }

            return new FourthGrade().Calculate(salary);
        }
    }
}
