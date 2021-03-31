using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Price.Kafka.Producer.Interfaces
{
    public interface IDependentProducer<TKey, TValue>
    {
        void Flush(TimeSpan timeout);

        /// <summary>
        ///     Asynchronously produce a message and expose delivery information
        ///     via the provided callback function. Use this method of producing
        ///     if you would like flow of execution to continue immediately, and
        ///     handle delivery information out-of-band.
        /// </summary>
        void Produce([NotNull] string topic, [NotNull] Message<TKey, TValue> message, [CanBeNull] Action<DeliveryReport<TKey, TValue>> deliveryHandler = null);

        /// <summary>
        ///     Asynchronously produce a message and expose delivery information
        ///     via the returned Task. Use this method of producing if you would
        ///     like to await the result before flow of execution continues.
        /// </summary>
        [NotNull]
        Task ProduceAsync([NotNull] string topic, [NotNull] Message<TKey, TValue> message);
    }
}