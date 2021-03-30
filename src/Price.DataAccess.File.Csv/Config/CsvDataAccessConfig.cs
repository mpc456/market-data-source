using System;
using System.Collections.Generic;
using System.Text;

namespace Price.DataAccess.File.Csv.Config
{
    public class CsvDataAccessConfig
    {
        public string CurrencyRatePath { get; set; } = @"Data\currencyRate.csv";
        public string CurrencyPath { get; set; } = @"Data\currency.csv";
    }
}
