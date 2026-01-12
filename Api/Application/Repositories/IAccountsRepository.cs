using Api.Domain.Entities;

namespace Api.Application.Repositories
{
    public interface IAccountsRepository
    {
        Task<Accounts?> GetByIdAsync(Guid id);
        Task<List<Accounts>> GetAllAsync();
        Task AddAsync(Accounts account);
        Task UpdateAsync(Accounts account);
        Task DeleteAsync(Guid id);
    }
}
