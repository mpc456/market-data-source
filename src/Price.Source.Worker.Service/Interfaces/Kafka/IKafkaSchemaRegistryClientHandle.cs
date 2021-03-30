using Confluent.SchemaRegistry;

namespace Price.Source.Worker.Service.Interfaces.Kafka
{
    public interface IKafkaSchemaRegistryClientHandle
    {
        ISchemaRegistryClient Handle { get; }
    }

}
