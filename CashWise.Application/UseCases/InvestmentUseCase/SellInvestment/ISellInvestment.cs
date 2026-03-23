using CashWise.Domain.ValueObject;

namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestment
{
    public interface ISellInvestment
    {
        public Task<SellResult> Sell(string asset, int quantity, decimal price);
    }
}
