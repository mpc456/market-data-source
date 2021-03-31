using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Price.Kafka.Producer.Interfaces;

namespace Price.Kafka.Producer.Services
{
    public class DependentProducer<TKey, TValue> : IDependentProducer<TKey, TValue>
    {
        private readonly IProducer<TKey, TValue> _innerProducer;

        public DependentProducer(IProducerFactory<TKey, TValue> producerFactory)
        {
            _innerProducer = producerFactory.Create();
        }

        public Task ProduceAsync(string topic, Message<TKey, TValue> message)
        {
            return _innerProducer.ProduceAsync(topic, message);
        }


        public void Produce(string topic, Message<TKey, TValue> message,
            Action<DeliveryReport<TKey, TValue>> deliveryHandler = null)
        {
            _innerProducer.Produce(topic, message, deliveryHandler);
        }

        public void Flush(TimeSpan timeout)
        {
            _innerProducer.Flush(timeout);
        }
    }
}