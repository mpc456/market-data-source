using Confluent.Kafka;
using Confluent.SchemaRegistry.Serdes;
using Price.Source.Worker.Service.Interfaces.Kafka;

namespace Price.Source.Worker.Service.Services.Kafka
{
    public class KafkaJsonSerializerFactory : IKafkaJsonSerializerFactory
    {
        private readonly IKafkaSchemaRegistryClientHandle registryHandle;
        private readonly JsonSerializerConfig jsonSerializerConfig;

        public KafkaJsonSerializerFactory(IKafkaSchemaRegistryClientHandle registryHandle)
        {
            this.registryHandle = registryHandle;

            jsonSerializerConfig = new JsonSerializerConfig
            {
                BufferBytes = 100
            };
        }

        public IAsyncSerializer<V> Create<V>() where V : class
        {
            return new JsonSerializer<V>(registryHandle.Handle, jsonSerializerConfig);
        }
    }
}
