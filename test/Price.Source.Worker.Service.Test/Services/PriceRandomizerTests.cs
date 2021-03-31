using Price.Source.Worker.Service.Services;
using Xunit;

namespace Price.Source.Worker.Service.Test.Services
{
    public class PriceRandomizerTests
    {
        [Fact]
        public void CanRandomizePrices()
        {
            var priceRandomizer = new PriceRandomizer();
            var currentPrice = 100M;
            var volatility = 2;
            for(int i =0; i< 100; i++)
            {
                currentPrice = priceRandomizer.GetNext(currentPrice, volatility);
            }
        }
    }
}
