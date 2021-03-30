using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Price.DataModel.Kafka.Config;
using Price.DataModel.Kafka.DependencyInjection;
using Price.DataModel.Kafka.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Price.DataModel.Kafka.Test.DependencyInjection
{
    public class ServiceCollectionExtensionsTests
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceCollectionExtensionsTests()
        {
            var config = new KafkaDataModelConfig();
            var services = new ServiceCollection();
            services.AddLogging(lb => lb.AddDebug());
            services.AddKafkaDataModelLibrary(config);
            _serviceProvider = services.BuildServiceProvider();
        }

        [Theory]
        [InlineData(typeof(ISchemaRegistryClientHandle))]
        [InlineData(typeof(ISerializerFactory))]
        [InlineData(typeof(IAsyncSerializer<CurrencyRate>))]
        [InlineData(typeof(IAsyncSerializer<Currency>))]
        public void CanResolveExpectedType(Type expectedType)
        {
            Assert.NotNull(_serviceProvider.GetRequiredService(expectedType));
        }
    }
}
