using CsvHelper.Configuration;
using Price.DataModel;

namespace Price.DataAccess.File.Csv.Mappers
{
    public class CurrencyRateMap : ClassMap<CurrencyRate>
    {
        public CurrencyRateMap()
        {
            Map(m => m.From).Name("from");
            Map(m => m.To).Name("to");
            Map(m => m.Rate).Name("rate");
        }
    }
}
