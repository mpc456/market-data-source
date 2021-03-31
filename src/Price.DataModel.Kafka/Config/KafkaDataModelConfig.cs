using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace Price.DataModel.Kafka.Config
{
    public class KafkaDataModelConfig
    {
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

        public SchemaRegistryConfig SchemaRegistry { get; set; }
        public JsonSerializerConfig Json { get; set; }
    }
}