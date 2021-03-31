using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Price.DataModel;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.DependencyInjection;
using Price.Kafka.Producer.Config;
using Price.Kafka.Producer.DependencyInjection;
using Price.Kafka.Producer.Interfaces;
using Xunit;

namespace Price.Kafka.Producer.Test.DependencyInjection
{
    public class ServiceCollectionExtensionsTests
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceCollectionExtensionsTests()
        {
            var dataModelConfig = new KafkaDataModelConfig();
            var producerConfig = new KafkaProducerConfig();
            var services = new ServiceCollection();
            services.AddLogging(lb => lb.AddDebug());
            services.AddKafkaDataModelLibrary(dataModelConfig);
            services.AddKafkaProducerLibrary(producerConfig);
            _serviceProvider = services.BuildServiceProvider();
        }

        [Theory]
        [InlineData(typeof(KafkaProducerConfig))]
        [InlineData(typeof(IProducerHandle))]
        [InlineData(typeof(IDependentProducer<string, Currency>))]
        [InlineData(typeof(IDependentProducer<string, CurrencyRate>))]
        [InlineData(typeof(IProducerFactory<string, Currency>))]
        [InlineData(typeof(IProducerFactory<string, CurrencyRate>))]
        public void CanResolveExpectedType(Type expectedType)
        {
            Assert.NotNull(_serviceProvider.GetRequiredService(expectedType));
        }
    }
}
