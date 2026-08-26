using CashWise.Application.Repositories;
using CashWise.Domain.Entities;
using CashWise.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CashWise.Infrastructure.Repositories
{
    internal class TransactionRepository(AppDbContext context) : ITransactionRepository 
    {
        /// <inheritdoc />
        public async Task<List<Transaction>> GetAllTransactionsAsync() =>
            await context.Transactions.ToListAsync();
        
        /// <inheritdoc />
        public async Task<Transaction?> GetTransactionByIdAsync(int id) =>
            await context.Transactions.FindAsync(id);

        /// <inheritdoc />
        public async Task CreateTransactionAsync(Transaction transaction)
        {
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
        }
    }
}
