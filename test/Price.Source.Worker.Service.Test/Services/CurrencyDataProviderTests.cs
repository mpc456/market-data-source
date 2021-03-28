using Microsoft.Extensions.Logging;
using Moq;
using Price.Source.Worker.Service.Services;
using System;
using Xunit;

namespace Price.Source.Worker.Service.Test
{
    public class CurrencyDataProviderTests
    {
        [Fact]
        public void CanGetRates()
        {
            var dataProvider = new CurrencyDataProvider(new Mock<ILogger<CurrencyDataProvider>>().Object);
            var currencies = dataProvider.GetRates();
            Assert.NotNull(currencies);
        }
    }
}
