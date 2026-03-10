namespace CashWise.Application.UseCases.InvestmentUseCase.BuyInvestmentUseCase
{
    public interface IBuyInvestmentUseCase
    {
        public Task Execute(int id, string asset, int quantity, decimal price);
    }
}
