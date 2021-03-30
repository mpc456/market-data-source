using Confluent.Kafka;
using Confluent.SchemaRegistry.Serdes;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.Interfaces;

namespace Price.DataModel.Kafka.Services
{
    public class JsonSerializerFactory : ISerializerFactory
    {
        private readonly ISchemaRegistryClientHandle _registryHandle;
        private readonly JsonSerializerConfig _jsonSerializerConfig;

        public JsonSerializerFactory(ISchemaRegistryClientHandle registryHandle, KafkaDataModelConfig config)
        {
            _registryHandle = registryHandle;
            _jsonSerializerConfig = config.Json;
        }

        public IAsyncSerializer<V> Create<V>() where V : class
        {
            return new JsonSerializer<V>(_registryHandle.Handle, _jsonSerializerConfig);
        }
    }
}
