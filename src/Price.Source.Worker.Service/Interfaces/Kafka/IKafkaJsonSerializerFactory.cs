using Confluent.Kafka;

namespace Price.Source.Worker.Service.Interfaces.Kafka
{
    public interface IKafkaJsonSerializerFactory
    {
        IAsyncSerializer<V> Create<V>() where V : class;
    }
}