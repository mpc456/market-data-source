using Confluent.SchemaRegistry;
using Microsoft.Extensions.Configuration;
using Price.Source.Worker.Service.Interfaces.Kafka;
using System;

namespace Price.Source.Worker.Service.Services.Kafka
{
    public class CachedSchemaRegistryClientHandle : IDisposable, IKafkaSchemaRegistryClientHandle
    {
        readonly CachedSchemaRegistryClient schemaRegistryClient;

        public CachedSchemaRegistryClientHandle(IConfiguration config)
        {
            var conf = new SchemaRegistryConfig
            {
                Url = "http://localhost:8081"
            };
            schemaRegistryClient = new CachedSchemaRegistryClient(conf);
        }

        public ISchemaRegistryClient Handle { get => schemaRegistryClient; }

        public void Dispose()
        {
            schemaRegistryClient.Dispose();
        }
    }

}
