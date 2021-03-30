using CsvHelper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Price.DataAccess.Abstractions;
using Price.DataAccess.File.Csv.Config;
using Price.DataAccess.File.Csv.DependencyInjection;
using Price.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Price.DataAccess.File.Csv.Tests.DependencyInjection
{
    public class ServiceCollectionExtensionsTest
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceCollectionExtensionsTest()
        {
            var config = new CsvDataAccessConfig();
            var services = new ServiceCollection();
            services.AddLogging(lb => lb.AddDebug());
            services.AddDataAccessCsvLibrary(config);
            _serviceProvider = services.BuildServiceProvider();
        }

        [Theory]
        [InlineData(typeof(CsvDataAccessConfig))]
        [InlineData(typeof(ClassMap<Currency>))]
        [InlineData(typeof(ClassMap<CurrencyRate>))]
        [InlineData(typeof(ICurrencyDataProvider))]
        public void CanResolveExepectedType(Type expectedType)
        {
            Assert.NotNull(_serviceProvider.GetRequiredService(expectedType));
        }
    }
}
