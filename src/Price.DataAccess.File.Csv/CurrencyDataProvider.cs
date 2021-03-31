using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using Price.DataAccess.Abstractions;
using Price.DataAccess.File.Csv.Config;
using Price.DataModel;

namespace Price.DataAccess.File.Csv
{
    public class CurrencyDataProvider : ICurrencyDataProvider
    {
        private readonly Lazy<List<Currency>> _currency;
        private readonly Lazy<List<CurrencyRate>> _currencyRates;
        private readonly ILogger<CurrencyDataProvider> _logger;

        public CurrencyDataProvider(CsvDataAccessConfig config,
            ClassMap<Currency> currencyClassMap,
            ClassMap<CurrencyRate> currencyRateClassMap,
            ILogger<CurrencyDataProvider> logger)
        {
            _logger = logger;
            _currencyRates = CreateLazyInitialization(config.CurrencyRatePath, currencyRateClassMap);
            _currency = CreateLazyInitialization(config.CurrencyPath, currencyClassMap);
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return _currency.Value;
        }

        public IEnumerable<CurrencyRate> GetRates()
        {
            return _currencyRates.Value;
        }

        private Lazy<List<T>> CreateLazyInitialization<T>(string fileName, ClassMap<T> classMap)
        {
            return new Lazy<List<T>>(() => LoadFromFile(fileName, classMap));
        }


        private List<T> LoadFromFile<T>(string fileName, ClassMap<T> classMap)
        {
            _logger.LogInformation($"Loading file {fileName}");

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap(classMap);
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}