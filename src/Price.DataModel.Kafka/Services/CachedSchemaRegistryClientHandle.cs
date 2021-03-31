using System;
using Confluent.SchemaRegistry;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.Interfaces;

namespace Price.DataModel.Kafka.Services
{
    public class CachedSchemaRegistryClientHandle : IDisposable, ISchemaRegistryClientHandle
    {
        private readonly CachedSchemaRegistryClient schemaRegistryClient;

        public CachedSchemaRegistryClientHandle(KafkaDataModelConfig config)
        {
            schemaRegistryClient = new CachedSchemaRegistryClient(config.SchemaRegistry);
        }

        public void Dispose()
        {
            schemaRegistryClient.Dispose();
        }

        public ISchemaRegistryClient Handle => schemaRegistryClient;
    }
}