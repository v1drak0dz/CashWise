using CashWise.Application.UseCases.TransactionUseCase.CreateTransaction;
using CashWise.Domain.Repositories;
using CashWise.Infrastructure.Repositories;
using CashWise.Application.Mappers;
using CashWise.Application.Orchestrator.TransactionOrchestrator;

namespace CashWise.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ServiceInjection(this IServiceCollection services)
        {
            #region [Account]


            #endregion [Account]

            #region [Transaction]

            services.AddScoped<ICreateTransaction, CreateTransaction>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionOrchestrator,  TransactionOrchestrator>();

            #endregion [Transaction]

            #region [Mapper]

            services.AddAutoMapper(typeof(TransactionMapper).Assembly);

            #endregion [Mapper]

            return services;
        }
    }
}