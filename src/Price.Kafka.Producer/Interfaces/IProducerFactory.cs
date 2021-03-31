using Confluent.Kafka;
using JetBrains.Annotations;

namespace Price.Kafka.Producer.Interfaces
{
    public interface IProducerFactory<TKey, TValue>
    {
        [NotNull]
        IProducer<TKey, TValue> Create();
    }
}