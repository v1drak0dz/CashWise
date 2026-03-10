namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestmentUseCase
{
    public interface ISellInvestmentUseCase
    {
        public Task Execute(int id, string asset, int quantity, decimal price);
    }
}
