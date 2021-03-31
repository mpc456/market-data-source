using System;
using Price.Source.Worker.Service.Interfaces;

namespace Price.Source.Worker.Service.Services
{
    public class PriceRandomizer : IPriceRandomizer
    {
        /// <summary>
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public decimal GetNext(decimal original, int volitility)
        {
            var random = new Random().Next(-volitility, volitility);
            var percentageChange = original / 100 * random;

            var nextPrice = original + percentageChange;

            return Math.Round(nextPrice, 4);
        }
    }
}