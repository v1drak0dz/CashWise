using CashWise.Domain.Entities;

namespace CashWise.Domain.Repositories
{
    public interface IInvestmentPositionRepository
    {
        Task<InvestmentPosition?> GetInvestmentPositionAsync(string asset);
        Task AddInvestmentPositionAsync(InvestmentPosition investmentPosition);
        Task UpdateInvestmentPositionAsync(InvestmentPosition investmentPosition);
    }
}
