using System.Threading.Tasks;
using Confluent.Kafka;
using Price.DataModel.Kafka.Interfaces;

namespace Price.DataModel.Kafka.Services
{
    public class CurrencyRateSerializer : IAsyncSerializer<CurrencyRate>
    {
        private readonly IAsyncSerializer<CurrencyRate> _serializer;

        public CurrencyRateSerializer(ISerializerFactory serializerFactory)
        {
            _serializer = serializerFactory.Create<CurrencyRate>();
        }

        public Task<byte[]> SerializeAsync(CurrencyRate data, SerializationContext context)
        {
            return _serializer.SerializeAsync(data, context);
        }
    }
}