namespace CashWise.Application.UseCases.InvestmentUseCase.BuyInvestment
{
    public interface IBuyInvestment
    {
        public Task Buy(string asset, int quantity, decimal price);
    }
}
