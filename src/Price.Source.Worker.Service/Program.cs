using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Price.DataAccess.File.Csv.Config;
using Price.DataAccess.File.Csv.DependencyInjection;
using Price.DataModel;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Interfaces.Kafka;
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
                    services.AddLogging(logBuilder => logBuilder.AddConsole());
                    services.AddDataAccessCsvLibrary(hostContext.Configuration);


                    services.AddTransient<IPriceRandomizer, PriceRandomizer>();
                    services.AddSingleton<IKafkaClientHandle, KafkaClientHandle>();
                    services.AddSingleton<IKafkaSchemaRegistryClientHandle, CachedSchemaRegistryClientHandle>();
                    services.AddTransient<IKafkaJsonSerializerFactory, KafkaJsonSerializerFactory>();
                    services.AddSingleton<IKafkaDependentProducer<string, CurrencyRate>, KafkaDependentProducer<string, CurrencyRate>>();

                    services.AddTransient<IAsyncSerializer<CurrencyRate>>(sp => sp.GetRequiredService<IKafkaJsonSerializerFactory>().Create<CurrencyRate>());

                    services.AddHostedService<Worker>();
                });
    }
}
