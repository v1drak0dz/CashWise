using CashWise.Domain.Entities.Transaction;
using CashWise.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Application.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _db;

        public TransactionRepository(AppDbContext db)
            => _db = db;

        public async Task<Transaction?> GetByIdAsync(Guid id)
            => await _db.Transactions.FindAsync(id);

        public async Task<List<Transaction>> GetAllAsync()
            => await _db.Transactions.AsNoTracking().ToListAsync();

        public async Task AddAsync(Transaction transactions)
        {
            _db.Transactions.Add(transactions);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transactions)
        {
            _db.Transactions.Update(transactions);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Transactions.FindAsync(id);

            if (entity is null)
                throw new KeyNotFoundException("Transaction not found!");

            _db.Transactions.Remove(entity);
            await _db.SaveChangesAsync();

        }
    }
}
