using CashWise.Domain.Entities;

namespace CashWise.Application.Services.AccountService
{ 
    public interface IAccountService
    {
        Task<int> CreateAsync(string name);
        Task<Account?> GetAsync(int id);
        Task<IEnumerable<Account>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
