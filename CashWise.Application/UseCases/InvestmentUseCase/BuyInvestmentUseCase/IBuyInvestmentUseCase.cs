namespace CashWise.Application.UseCases.InvestmentUseCase.BuyInvestmentUseCase
{
    public interface IBuyInvestmentUseCase
    {
        public Task Execute(int id, int quantity, decimal price);
    }
}
