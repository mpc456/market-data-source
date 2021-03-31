using System;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Price.DataAccess.Abstractions;
using Price.DataAccess.File.Csv.Config;
using Price.DataAccess.File.Csv.Mappers;
using Price.DataModel;

namespace Price.DataAccess.File.Csv.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessCsvLibrary(this IServiceCollection services, IConfiguration config)
        {
            var csvConfig = config?
                                .GetSection(nameof(CsvDataAccessConfig))?
                                .Get<CsvDataAccessConfig>()
                            ?? throw new ArgumentNullException(
                                $"Missing configuration section for {nameof(CsvDataAccessConfig)}");

            services.AddDataAccessCsvLibrary(csvConfig);
        }

        public static void AddDataAccessCsvLibrary(this IServiceCollection services, CsvDataAccessConfig config)
        {
            services.AddSingleton(config);
            services.AddTransient<ClassMap<Currency>, CurrencyMap>();
            services.AddTransient<ClassMap<CurrencyRate>, CurrencyRateMap>();
            services.AddSingleton<ICurrencyDataProvider, CurrencyDataProvider>();
        }
    }
}