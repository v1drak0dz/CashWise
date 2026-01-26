using CashWise.Application.Repositories.AccountRepository;
using CashWise.Domain.Entities.Account;

namespace CashWise.Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Guid> CreateAsync(string name)
        {
            var account = new Account(name);
            
            await _accountRepository.AddAsync(account);
            return account.Id;
        }

        public async Task<IAccount?> GetAsync(Guid id) =>
            await _accountRepository.GetByIdAsync(id);

        public async Task<IEnumerable<IAccount>> GetAllAsync()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAllAsync();

            return accounts;
        }

        public async Task DeleteAsync(Guid id) =>
            await _accountRepository.DeleteAsync(id);
    }
}