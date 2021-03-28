using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Price.Source.Worker.Service
{
    public class Worker : BackgroundService
    {
        private readonly ICurrencyDataProvider _currencyDataProvider;
        private readonly IPriceRandomizer _priceRandomizer;
        private readonly ILogger<Worker> _logger;

        public Worker(ICurrencyDataProvider currencyDataProvider, 
            IPriceRandomizer priceRandomizer, 
            ILogger<Worker> logger)
        {
            _currencyDataProvider = currencyDataProvider;
            _priceRandomizer = priceRandomizer;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var rates = _currencyDataProvider.GetRates();

            while (!stoppingToken.IsCancellationRequested)
            {
                LogRates(rates);

                rates = RandomizeRates(rates);

                await Task.Delay(1000, stoppingToken);
            }
        }

        private List<CurrencyRate> RandomizeRates(List<CurrencyRate> originalRates)
        {
            List<CurrencyRate> newRates = new List<CurrencyRate>();
            foreach(var rate in originalRates)
            {
                var newPrice = _priceRandomizer.GetNext(rate.Rate, 3);
                newRates.Add(new CurrencyRate() { From = rate.From, To = rate.To, Rate = newPrice });
            }
            return newRates;
        }

        private void LogRates(List<CurrencyRate> rates)
        {
            foreach(var rate in rates)
            {
                _logger.LogInformation($"{rate.From}->{rate.To}:{rate.Rate}");
            }
        }
    }
}
