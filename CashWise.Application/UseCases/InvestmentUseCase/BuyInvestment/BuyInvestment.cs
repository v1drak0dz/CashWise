using CashWise.Application.Factories.InvestmentPositionFactory;
using CashWise.Domain.Repositories;

namespace CashWise.Application.UseCases.InvestmentUseCase.BuyInvestment
{
    public class BuyInvestment : IBuyInvestment
    {
        private readonly IInvestmentPositionRepository _investmentRepository;
        private IInvestmentPositionFactory _investmentPositionFactory;

        public BuyInvestment(IInvestmentPositionRepository investmentRepository, IInvestmentPositionFactory investmentPositionFactory)
        {
            _investmentRepository = investmentRepository;
            _investmentPositionFactory = investmentPositionFactory;
        }

        public async Task Buy(string asset, int quantity, decimal price)
        {
            var position = await _investmentRepository.GetInvestmentPositionAsync(asset);

            if (position == null)
            {
                position = _investmentPositionFactory.Create(asset);
                await _investmentRepository.AddInvestmentPositionAsync(position);
            }

            position.Buy(price, quantity);

            await _investmentRepository.UpdateInvestmentPositionAsync(position);
        }
    }
}
