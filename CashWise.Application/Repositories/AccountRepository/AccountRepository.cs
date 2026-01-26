using CashWise.Domain.Entities.Account;
using CashWise.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Application.Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        // Privates (Fields)
        private readonly AppDbContext _db; // To be testable

        // Publics (Properties)

        // Constructors
        public AccountRepository(AppDbContext db) => _db = db;

        // Methods -> Publics -> Privates
        public async Task<Account?> GetByIdAsync(Guid id) =>
            await _db.Accounts.FindAsync(id);

        public async Task<List<Account>> GetAllAsync() =>
            await _db.Accounts.AsNoTracking().ToListAsync();

        public async Task AddAsync(Account accounts)
        {
            _db.Accounts.Add(accounts);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account accounts)
        {
            _db.Accounts.Update(accounts);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Accounts.FindAsync(id);
            
            if (entity is null)
                throw new KeyNotFoundException("Account not found");
            
            _db.Accounts.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}