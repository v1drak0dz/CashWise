using CashWise.Application.Services.AccountService;
using CashWise.Application.Services.TransactionService;
using Microsoft.Extensions.DependencyInjection;

namespace CashWise.Application
{
    public static class ApplicationServiceInjection
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
