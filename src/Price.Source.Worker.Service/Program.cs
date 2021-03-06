using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Price.DataAccess.File.Csv.DependencyInjection;
using Price.DataModel.Kafka.DependencyInjection;
using Price.Kafka.Producer.DependencyInjection;
using Price.Source.Worker.Service.Interfaces;
using Price.Source.Worker.Service.Services;

namespace Price.Source.Worker.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(logBuilder => logBuilder.AddConsole());
                    services.AddDataAccessCsvLibrary(hostContext.Configuration);
                    services.AddKafkaDataModelLibrary(hostContext.Configuration);
                    services.AddKafkaProducerLibrary(hostContext.Configuration);
                    services.AddTransient<IPriceRandomizer, PriceRandomizer>();
                    services.AddHostedService<Worker>();
                });
        }
    }
}