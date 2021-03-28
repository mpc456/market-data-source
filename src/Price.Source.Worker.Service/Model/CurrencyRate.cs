using CsvHelper.Configuration.Attributes;

namespace Price.Source.Worker.Service.Model
{
    public class CurrencyRate
    {
        [Name("from")]
        public string From { get; set; }

        [Name("to")]
        public string To { get; set; }

        [Name("rate")]
        public decimal Rate { get; set; }
    }
    
}
