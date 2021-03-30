using Confluent.SchemaRegistry;
using Microsoft.Extensions.Configuration;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.Interfaces;
using System;

namespace Price.DataModel.Kafka.Services
{
    public class CachedSchemaRegistryClientHandle : IDisposable, ISchemaRegistryClientHandle
    {
        readonly CachedSchemaRegistryClient schemaRegistryClient;

        public CachedSchemaRegistryClientHandle(KafkaDataModelConfig config)
        {
            schemaRegistryClient = new CachedSchemaRegistryClient(config.SchemaRegistry);
        }

        public ISchemaRegistryClient Handle { get => schemaRegistryClient; }

        public void Dispose()
        {
            schemaRegistryClient.Dispose();
        }
    }

}
