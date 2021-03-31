using Confluent.Kafka;

namespace Price.Kafka.Producer.Config
{
    public class KafkaProducerConfig
    {
        public KafkaProducerConfig()
        {
            Config = new ProducerConfig
            {
                BootstrapServers = "http://localhost:9092"
            };
        }

        public ProducerConfig Config { get; set; }

        public string CurrencyTopicName { get; set; } = "currency";

        public string CurrencyRateTopicName { get; set; } = "currency-rate";
    }
}