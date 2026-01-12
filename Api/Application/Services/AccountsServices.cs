using Api.Application.Repositories;
using Api.Domain.Entities;

namespace Api.Application.Services
{
    public class AccountsServices
    {
        private readonly IAccountsRepository _repo;

        public AccountsServices(IAccountsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateAsync(string name)
        {
            Accounts account = new Accounts(name);
            await _repo.AddAsync(account);
            return account.Id;
        }


        public Task<Accounts?> GetAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task<List<Accounts>> GetAllAsync() => _repo.GetAllAsync();

        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
