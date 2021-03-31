using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Price.DataModel;
using Price.Kafka.Producer.Config;
using Price.Kafka.Producer.Interfaces;
using Price.Kafka.Producer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Price.Kafka.Producer.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddKafkaProducerLibrary([NotNull] this IServiceCollection services, 
            [NotNull] IConfiguration config)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (config == null) throw new ArgumentNullException(nameof(config));

            var producerConfig = config
                                     ?.GetSection(nameof(KafkaProducerConfig))
                                     ?.Get<KafkaProducerConfig>()
                                 ?? throw new ArgumentNullException($"Missing configuration section for {nameof(KafkaProducerConfig)}");
            services.AddKafkaProducerLibrary(producerConfig);
        }

        public static void AddKafkaProducerLibrary([NotNull] this IServiceCollection services,
            [NotNull] KafkaProducerConfig config)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (config == null) throw new ArgumentNullException(nameof(config));

            services.AddSingleton(config);
            services.AddSingleton<IProducerHandle, ProducerHandle>();
            services.AddSingleton<IDependentProducer<string, Currency>, CurrencyProducer>();
            services.AddSingleton<IDependentProducer<string, CurrencyRate>, CurrencyRateProducer>();
            services.AddTransient<IProducerFactory<string, Currency>, ProducerFactory<string, Currency>>();
            services.AddTransient<IProducerFactory<string, CurrencyRate>, ProducerFactory<string, CurrencyRate>>();

        }
    }
}
