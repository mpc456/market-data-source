
using Price.DataModel;

namespace Price.Source.Worker.Service.Interfaces
{
    public interface IKafkaPublisher
    {
        void Publish(CurrencyRate rate);
    }
}