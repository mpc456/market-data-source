using System;
using Confluent.Kafka;
using JetBrains.Annotations;
using Price.Kafka.Producer.Config;
using Price.Kafka.Producer.Interfaces;

namespace Price.Kafka.Producer.Services
{
    public class ProducerFactory<TKey, TValue> : IProducerFactory<TKey, TValue>
    {
        [NotNull] private readonly Action<ProducerBuilder<TKey, TValue>> _builderConfig;
        [NotNull] private readonly KafkaProducerConfig _producerConfig;

        public ProducerFactory([NotNull] KafkaProducerConfig producerConfig, IAsyncSerializer<TValue> valueSerializer)
        {
            _producerConfig = producerConfig ?? throw new ArgumentNullException(nameof(producerConfig));
            _builderConfig = builder => { builder.SetValueSerializer(valueSerializer); };
        }

        public IProducer<TKey, TValue> Create()
        {
            var builder = new ProducerBuilder<TKey, TValue>(_producerConfig.Config);
            _builderConfig.Invoke(builder);
            return builder.Build();
        }
    }
}