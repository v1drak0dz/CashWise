using CashWise.Application.UseCases.TransactionUseCase.CreateTransaction;
using CashWise.Domain.Repositories;
using CashWise.Infrastructure.Repositories;
using CashWise.Application.Orchestrator.TransactionOrchestrator;
using CashWise.Application;
using AutoMapper;
using CashWise.Application.UseCases.TransactionUseCase.GetTransaction;

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
            services.AddScoped<IGetTransaction, GetTransaction>();

            #endregion [Transaction]

            #region [Mapper]

            services.AddAutoMapper(typeof(CashWiseMapper));

            #endregion [Mapper]

            return services;
        }
    }
}