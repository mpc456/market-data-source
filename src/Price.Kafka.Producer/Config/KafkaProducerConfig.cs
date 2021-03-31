using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Price.Kafka.Producer.Config
{
    public class KafkaProducerConfig
    {
        public ProducerConfig Config { get; set; }

        public string CurrencyTopicName { get; set; } = "currency";

        public string CurrencyRateTopicName { get; set; } = "currency-rate";

        public KafkaProducerConfig()
        {
            Config = new ProducerConfig()
            {
                BootstrapServers = "http://localhost:9092"
            };
        }
    }
}
