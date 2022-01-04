using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Repositories;
using CarteiraApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace CarteiraApi.Config
{

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IExchangeRateService, ExchangeRateService>(client =>
            {
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("YahooStockApi"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("YahooStockApiKey"));
            });
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IOperationService, OperationService>();

            var connectionString = Environment.GetEnvironmentVariable("SqlConnection");
            services.AddTransient<IStockRepository>(repo => new StockRepository(connectionString));
            services.AddTransient<IOperationRepository>(repo => new OperationRepository(connectionString));
            services.AddTransient<IStockParameterRepository>(repo => new StockParameterRepository(connectionString));
            

            return services;
        }
    }
}
