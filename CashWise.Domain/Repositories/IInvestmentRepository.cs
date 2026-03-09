using CashWise.Domain.Entities;

namespace CashWise.Domain.Repositories
{
    public interface IInvestmentRepository
    {
        Task<InvestmentPosition?> GetInvestmentPositionAsync(int investmentPositionId);
        Task AddInvestmentPositionAsync(InvestmentPosition investmentPosition);
        Task UpdateInvestmentPositionAsync(InvestmentPosition investmentPosition);
    }
}
