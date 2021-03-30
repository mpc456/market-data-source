using CsvHelper.Configuration;
using Price.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Price.DataAccess.File.Csv.Mappers
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            Map(m => m.Code).Name("code");
            Map(m => m.Name).Name("name");
        }
    }
}
