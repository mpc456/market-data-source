using Price.DataModel;
using System.Collections.Generic;

namespace Price.DataAccess.Abstractions
{
    public interface ICurrencyDataProvider
    {
        IEnumerable<Currency> GetCurrencies();

        IEnumerable<CurrencyRate> GetRates();
    }
}