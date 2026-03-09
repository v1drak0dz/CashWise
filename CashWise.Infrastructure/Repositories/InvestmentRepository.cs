using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;

namespace CashWise.Infrastructure.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvestmentRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task<InvestmentPosition?> GetInvestmentPositionAsync(int investmentPositionId) =>
            await _appDbContext.InvestmentPositions.FindAsync(investmentPositionId);

        public async Task AddInvestmentPositionAsync(InvestmentPosition investment)
        {
            await _appDbContext.InvestmentPositions.AddAsync(investment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateInvestmentPositionAsync(InvestmentPosition investment)
        {
            _appDbContext.InvestmentPositions.Update(investment);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
