using Price.Source.Worker.Service.Model;

namespace Price.Source.Worker.Service.Interfaces
{
    public interface IKafkaPublisher
    {
        void Publish(CurrencyRate rate);
    }
}