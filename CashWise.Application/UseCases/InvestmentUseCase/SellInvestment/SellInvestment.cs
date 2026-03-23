using CashWise.Domain.Repositories;
using CashWise.Domain.ValueObject;
using CashWise.Application.Strategies.Interfaces;

namespace CashWise.Application.UseCases.InvestmentUseCase.SellInvestment
{
    public class SellInvestment : ISellInvestment
    {
        private readonly IInvestmentPositionRepository _investmentRepository;

        public SellInvestment(IInvestmentPositionRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<SellResult> Sell(string asset, int quantity, decimal price)
        {
            var position = await _investmentRepository.GetInvestmentPositionAsync(asset);

            if (position == null)
                throw new ArgumentNullException("Investment position not found");

            var profit = position.Sell(price, quantity);

            await _investmentRepository.UpdateInvestmentPositionAsync(position);

            var tax = 0m;

            return SellResult.Create(profit, tax);
        }
    }
}
