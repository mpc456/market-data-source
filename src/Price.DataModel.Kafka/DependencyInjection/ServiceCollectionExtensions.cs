using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.Interfaces;
using Price.DataModel.Kafka.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Price.DataModel.Kafka.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
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
