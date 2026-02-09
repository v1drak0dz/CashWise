using CashWise.Domain.IRepositories;
using CashWise.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashWise.Infrastructure
{
    public static class InfrastructureServiceInjection
    {
        public static IServiceCollection AddInfrastructureServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
