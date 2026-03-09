using CashWise.Domain.Repositories;

namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestmentUseCase
{
    public class SellInvestmentUseCase : ISellInvestmentUseCase
    {
        private readonly IInvestmentRepository _investmentRepository;

        public SellInvestmentUseCase(IInvestmentRepository investmentRepository) =>
            _investmentRepository = investmentRepository;

        public async Task Execute(int id, int quantity, decimal price)
        {
            var position = await _investmentRepository.GetInvestmentPositionAsync(id);

            if (position == null)
                throw new InvalidOperationException("Investment position not found");

            position.Sell(price, quantity);

            await _investmentRepository.UpdateInvestmentPositionAsync(position);
        }
    }
}
