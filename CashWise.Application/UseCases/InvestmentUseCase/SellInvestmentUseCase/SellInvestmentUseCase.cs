using CashWise.Application.Factories.InvestmentPositionFactory;
using CashWise.Domain.Repositories;

namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestmentUseCase
{
    public class SellInvestmentUseCase : ISellInvestmentUseCase
    {
        private readonly IInvestmentRepository _investmentRepository;
        private IInvestmentPositionFactory _investmentPositionFactory;

        public SellInvestmentUseCase(IInvestmentRepository investmentRepository, IInvestmentPositionFactory investmentPositionFactory)
        {
            _investmentRepository = investmentRepository;
            _investmentPositionFactory = investmentPositionFactory;
        }

        public async Task Execute(int id, string asset, int quantity, decimal price)
        {
            var position = await _investmentRepository.GetInvestmentPositionAsync(id);

            if (position == null)
            {
                position = _investmentPositionFactory.Create(asset);
                await _investmentRepository.AddInvestmentPositionAsync(position);
            }

            position.Sell(price, quantity);

            await _investmentRepository.UpdateInvestmentPositionAsync(position);
        }
    }
}
