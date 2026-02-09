using CashWise.Domain.Entities;
using CashWise.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // Privates (Fields)
        private readonly AppDbContext _context; // To be testable

        // Publics (Properties)

        // Constructors
        public AccountRepository(AppDbContext context) => _context = context;

        // Methods -> Publics -> Privates
        public async Task<Account?> GetByIdAsync(int id) =>
            await _context.Accounts.FindAsync(id);

        public async Task<List<Account>> GetAllAsync() =>
            await _context.Accounts.ToListAsync();

        public async Task AddAsync(Account accounts)
        {
            _context.Accounts.Add(accounts);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account accounts)
        {
            _context.Accounts.Update(accounts);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            
            if (entity is null)
                throw new KeyNotFoundException("Account not found");
            
            _context.Accounts.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}