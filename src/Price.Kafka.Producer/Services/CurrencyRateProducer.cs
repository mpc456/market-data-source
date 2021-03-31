using Price.DataModel;
using Price.Kafka.Producer.Interfaces;

namespace Price.Kafka.Producer.Services
{
    public class CurrencyRateProducer : DependentProducer<string, CurrencyRate>
    {
        public CurrencyRateProducer(IProducerFactory<string, CurrencyRate> factory) : base(factory)
        {
        }
    }
}