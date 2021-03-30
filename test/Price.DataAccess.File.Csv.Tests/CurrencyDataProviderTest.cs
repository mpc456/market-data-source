using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Price.DataAccess.Abstractions;
using Price.DataAccess.File.Csv.Config;
using Price.DataAccess.File.Csv.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace Price.DataAccess.File.Csv.Tests
{
    public class CurrencyDataProviderTest
    {
        private readonly ICurrencyDataProvider _dataProvider;

        public CurrencyDataProviderTest()
        {
            var config = new CsvDataAccessConfig()
            {
                CurrencyPath = @"Files\currency.csv",
                CurrencyRatePath = @"Files\currencyRate.csv"
            };
            var services = new ServiceCollection();
            services.AddLogging(lb => lb.AddDebug());
            services.AddDataAccessCsvLibrary(config);
            var serviceProvider = services.BuildServiceProvider();
            _dataProvider = serviceProvider.GetRequiredService<ICurrencyDataProvider>();
        }

        [Fact]
        public void CanLoadCurrencies()
        {
            var currencies = _dataProvider.GetCurrencies()?.ToList();
            Assert.NotNull(currencies);
            Assert.Equal(4, currencies.Count);
            Assert.Contains(currencies, currency => currency.Code.Equals("GBP"));
            Assert.Contains(currencies, currency => currency.Code.Equals("EUR"));
            Assert.Contains(currencies, currency => currency.Code.Equals("USD"));
            Assert.Contains(currencies, currency => currency.Code.Equals("JPY"));

        }

        [Fact]
        public void CanLoadRates()
        {
            var rates = _dataProvider.GetRates()?.ToList();
            Assert.NotNull(rates);
            Assert.Equal(3, rates.Count);
        }
    }
}
