using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Interfaces.Kafka;
using Price.Source.Worker.Service.Model;
using Price.Source.Worker.Service.Services;
using Price.Source.Worker.Service.Services.Kafka;

namespace Price.Source.Worker.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IPriceRandomizer, PriceRandomizer>();
                    services.AddTransient<ICurrencyDataProvider, CurrencyDataProvider>();
                    services.AddSingleton<IKafkaClientHandle, KafkaClientHandle>();
                    services.AddSingleton<IKafkaSchemaRegistryClientHandle, CachedSchemaRegistryClientHandle>();
                    services.AddTransient<IKafkaJsonSerializerFactory, KafkaJsonSerializerFactory>();
                    services.AddSingleton<IKafkaDependentProducer<string, CurrencyRate>, KafkaDependentProducer<string, CurrencyRate>>();

                    services.AddTransient<IAsyncSerializer<CurrencyRate>>(sp => sp.GetRequiredService<IKafkaJsonSerializerFactory>().Create<CurrencyRate>());

                    services.AddHostedService<Worker>();
                });
    }
}
