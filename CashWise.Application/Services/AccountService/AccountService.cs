using CashWise.Domain.Entities;
using CashWise.Domain.IRepositories;

namespace CashWise.Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> CreateAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("[AccountService][CreateAsync] Invalid name to account: " + nameof(name));
                return -1;
            }

            var account = new Account(name);
            
            await _accountRepository.AddAsync(account);
            return account.Id;
        }

        public async Task<Account?> GetAsync(int id) =>
            await _accountRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();

            return accounts;
        }

        public async Task DeleteAsync(int id) =>
            await _accountRepository.DeleteAsync(id);
    }
}