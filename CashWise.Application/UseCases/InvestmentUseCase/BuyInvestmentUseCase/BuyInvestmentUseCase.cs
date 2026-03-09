using CashWise.Domain.Repositories;

namespace CashWise.Application.UseCases.InvestmentUseCase.BuyInvestmentUseCase
{
    public class BuyInvestmentUseCase : IBuyInvestmentUseCase
    {
        private readonly IInvestmentRepository _investmentRepository;

        public BuyInvestmentUseCase(IInvestmentRepository investmentRepository) =>
            _investmentRepository = investmentRepository;

        public async Task Execute(int id, int quantity, decimal price)
        {
            var position = await _investmentRepository.GetInvestmentPositionAsync(id);

            if (position == null)
                throw new InvalidOperationException("Investment position not found");

            position.Buy(price, quantity);

            await _investmentRepository.UpdateInvestmentPositionAsync(position);
        }
    }
}
