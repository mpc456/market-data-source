using Confluent.Kafka;
using JetBrains.Annotations;

namespace Price.Kafka.Producer.Interfaces
{
    public interface IProducerHandle
    {
        [NotNull] Handle Handle { get; }
    }

}
