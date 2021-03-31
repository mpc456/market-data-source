using System;
using Price.DataModel;
using Price.Kafka.Producer.Interfaces;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Price.Kafka.Producer.Services
{
    public class CurrencyProducer : DependentProducer<string, Currency>
    {
        public CurrencyProducer(IProducerFactory<string,Currency> factory) : base(factory)
        {

        }
    }
}
