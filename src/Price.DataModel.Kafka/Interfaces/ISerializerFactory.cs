using Confluent.Kafka;

namespace Price.DataModel.Kafka.Interfaces
{
    public interface ISerializerFactory
    {
        IAsyncSerializer<V> Create<V>() where V : class;
    }
}