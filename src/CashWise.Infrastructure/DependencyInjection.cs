using CashWise.Application.Repositories;
using CashWise.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashWise.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<ITransactionRepository, TransactionRepository>();
        return service;
    }
}