using Confluent.Kafka;

namespace Price.Source.Worker.Service.Services
{
    public interface IKafkaClientHandle
    {
        Handle Handle { get; }
    }

}
