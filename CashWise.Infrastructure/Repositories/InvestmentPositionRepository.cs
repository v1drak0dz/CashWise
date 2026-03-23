using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure.Repositories
{
    public class InvestmentPositionRepository : IInvestmentPositionRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvestmentPositionRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task<InvestmentPosition?> GetInvestmentPositionAsync(string asset) =>
            await _appDbContext.InvestmentPositions.FirstOrDefaultAsync(x => x.Asset == asset);

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
