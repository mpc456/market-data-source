using System;
using Confluent.Kafka;
using JetBrains.Annotations;
using Price.Kafka.Producer.Config;
using Price.Kafka.Producer.Interfaces;

namespace Price.Kafka.Producer.Services
{
    /// <summary>
    ///     Wraps a Confluent.Kafka.IProducer instance, and allows for basic
    ///     configuration of this via IConfiguration.
    ///     KafkaClientHandle does not provide any way for messages to be produced
    ///     directly. Instead, it is a dependency of KafkaDependentProducer. You
    ///     can create more than one instance of KafkaDependentProducer (with
    ///     possibly differing K and V generic types) that leverages the same
    ///     underlying producer instance exposed by the Handle property of this
    ///     class. This is more efficient than creating separate
    ///     Confluent.Kafka.IProducer instances for each Message type you wish to
    ///     produce.
    /// </summary>
    public class ProducerHandle : IDisposable, IProducerHandle
    {
        [NotNull] private readonly IProducer<byte[], byte[]> _kafkaProducer;

        public ProducerHandle([NotNull] KafkaProducerConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            _kafkaProducer = new ProducerBuilder<byte[], byte[]>(config.Config).Build();
        }

        public void Dispose()
        {
            // Block until all outstanding produce requests have completed (with or
            // without error).
            _kafkaProducer.Flush();
            _kafkaProducer.Dispose();
        }

        public Handle Handle => _kafkaProducer.Handle;
    }
}