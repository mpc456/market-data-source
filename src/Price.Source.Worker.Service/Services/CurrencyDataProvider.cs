using CsvHelper;
using Microsoft.Extensions.Logging;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Price.Source.Worker.Service.Services
{
    public class CurrencyDataProvider : ICurrencyDataProvider
    {
        private readonly ILogger<CurrencyDataProvider> _logger;
        private readonly Lazy<List<CurrencyRate>> _currencyRates;

        public CurrencyDataProvider(ILogger<CurrencyDataProvider> logger)
        {
            _logger = logger;
            _currencyRates = new Lazy<List<CurrencyRate>>(() => LoadFromFile<CurrencyRate>(@"Data\seed_rates.csv"));
        }

        public List<CurrencyRate> GetRates()
        {
            return _currencyRates.Value;
        }

        private List<T> LoadFromFile<T>(string fileName)
        {
            _logger.LogInformation($"Loading file {fileName}");

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
