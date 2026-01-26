using CashWise.Domain.Entities.Account;

namespace CashWise.Application.Services.AccountService
{ 
    public interface IAccountService
    {
        Task<Guid> CreateAsync(string name);
        Task<IAccount?> GetAsync(Guid id);
        Task<IEnumerable<IAccount>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
