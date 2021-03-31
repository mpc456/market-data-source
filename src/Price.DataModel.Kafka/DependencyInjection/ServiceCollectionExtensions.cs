using System;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.Interfaces;
using Price.DataModel.Kafka.Services;

namespace Price.DataModel.Kafka.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddKafkaDataModelLibrary(this IServiceCollection services, IConfiguration config)
        {
            var modelConfig = config
                                  ?.GetSection(nameof(KafkaDataModelConfig))
                                  ?.Get<KafkaDataModelConfig>()
                              ?? throw new ArgumentNullException(
                                  $"Missing configuration section for {nameof(KafkaDataModelConfig)}");

            services.AddKafkaDataModelLibrary(modelConfig);
        }

        public static void AddKafkaDataModelLibrary(this IServiceCollection services, KafkaDataModelConfig config)
        {
            services.AddSingleton(config);
            services.AddSingleton<ISchemaRegistryClientHandle, CachedSchemaRegistryClientHandle>();
            services.AddTransient<ISerializerFactory, JsonSerializerFactory>();
            services.AddTransient<IAsyncSerializer<CurrencyRate>, CurrencyRateSerializer>();
            services.AddTransient<IAsyncSerializer<Currency>, CurrencySerializer>();
        }
    }
}