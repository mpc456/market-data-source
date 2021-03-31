using System.Threading.Tasks;
using Confluent.Kafka;
using Price.DataModel.Kafka.Interfaces;

namespace Price.DataModel.Kafka.Services
{
    public class CurrencySerializer : IAsyncSerializer<Currency>
    {
        private readonly IAsyncSerializer<Currency> _serializer;

        public CurrencySerializer(ISerializerFactory serializerFactory)
        {
            _serializer = serializerFactory.Create<Currency>();
        }

        public Task<byte[]> SerializeAsync(Currency data, SerializationContext context)
        {
            return _serializer.SerializeAsync(data, context);
        }
    }
}