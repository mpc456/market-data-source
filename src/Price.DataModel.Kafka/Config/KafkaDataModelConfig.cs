using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Price.DataModel.Kafka.Config
{
    public class KafkaDataModelConfig
    {
        public SchemaRegistryConfig SchemaRegistry { get; set; }
        public JsonSerializerConfig Json { get; set; }

        public KafkaDataModelConfig()
        {
            SchemaRegistry = new SchemaRegistryConfig
            {
                Url = "http://localhost:8081"
            };
            Json = new JsonSerializerConfig
            {
                BufferBytes = 100
            };
        }
    }
}
