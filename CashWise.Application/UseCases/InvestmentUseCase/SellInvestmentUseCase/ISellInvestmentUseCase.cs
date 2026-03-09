namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestmentUseCase
{
    public interface ISellInvestmentUseCase
    {
        public Task Execute(int id, int quantity, decimal price);
    }
}
