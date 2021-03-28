using Price.Source.Worker.Service.Model;
using System.Collections.Generic;

namespace Price.Source.Worker.Service.Interfaces
{
    public interface ICurrencyDataProvider
    {
        List<CurrencyRate> GetRates();
    }
}