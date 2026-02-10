using CashWise.Application.Services.AccountService;
using CashWise.Application.Services.TransactionService;
using CashWise.Domain.IRepositories;
using CashWise.Infrastructure.Repositories;

namespace CashWise.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ServiceInjection(this IServiceCollection services)
        {
            #region [Account]

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            #endregion [Account]

            #region [Transaction]

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            #endregion [Transaction]

            return services;
        }
    }
}