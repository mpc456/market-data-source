using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Price.DataAccess.Abstractions;
using Price.DataModel;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Interfaces.Kafka;
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
        private readonly IKafkaDependentProducer<string, CurrencyRate> _kafkaPublisher;
        private readonly ILogger<Worker> _logger;

        public Worker(ICurrencyDataProvider currencyDataProvider, 
            IPriceRandomizer priceRandomizer,
            IKafkaDependentProducer<string, CurrencyRate> kafkaPublisher,
            ILogger<Worker> logger)
        {
            _currencyDataProvider = currencyDataProvider;
            _priceRandomizer = priceRandomizer;
            _kafkaPublisher = kafkaPublisher;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var rates = _currencyDataProvider.GetRates().ToList();

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

        private void PublisherRates(List<CurrencyRate> rates)
        {
            foreach (var rate in rates)
            {
                var message = new Message<string, CurrencyRate>() { Key = $"{rate.From}->{rate.To}:{rate.Rate}", Value = rate };
                _kafkaPublisher.Produce("currency-rates", message);
            }
        }
    }
}
