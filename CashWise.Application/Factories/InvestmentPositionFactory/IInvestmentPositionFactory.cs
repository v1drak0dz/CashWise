using CashWise.Domain.Entities;

namespace CashWise.Application.Factories.InvestmentPositionFactory
{
    public interface IInvestmentPositionFactory
    {
        InvestmentPosition Create(string asset);
    }
}
