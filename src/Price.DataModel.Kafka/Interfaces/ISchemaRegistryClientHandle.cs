using Confluent.SchemaRegistry;

namespace Price.DataModel.Kafka.Interfaces
{
    public interface ISchemaRegistryClientHandle
    {
        ISchemaRegistryClient Handle { get; }
    }
}