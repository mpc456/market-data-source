using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IPriceRandomizer, PriceRandomizer>();
                    services.AddTransient<ICurrencyDataProvider, CurrencyDataProvider>();
                    services.AddHostedService<Worker>();
                });
    }
}
