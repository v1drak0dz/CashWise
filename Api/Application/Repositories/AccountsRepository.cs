using Api.Domain.Entities;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _db;
        public AccountsRepository(AppDbContext db) => _db = db;
        public async Task<Accounts?> GetByIdAsync(Guid id) => await _db.Accounts.FindAsync(id);
        public async Task<List<Accounts>> GetAllAsync() => await _db.Accounts.AsNoTracking().ToListAsync();

        public async Task AddAsync(Accounts accounts)
        {
            _db.Accounts.Add(accounts);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Accounts accounts)
        {
            _db.Accounts.Update(accounts);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Accounts.FindAsync(id);
            if (entity is null) throw new KeyNotFoundException("Account not found");
            _db.Accounts.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
