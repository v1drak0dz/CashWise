using CashWise.Domain.Entities;

namespace CashWise.Application.Factories.InvestmentPositionFactory
{
    public class InvestmentPositionFactory : IInvestmentPositionFactory
    {
        public InvestmentPosition Create(string asset) =>
            new InvestmentPosition(asset, 0, 0m);
    }
}
