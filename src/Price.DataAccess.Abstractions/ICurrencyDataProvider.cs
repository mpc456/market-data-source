using System.Collections.Generic;
using Price.DataModel;

namespace Price.DataAccess.Abstractions
{
    public interface ICurrencyDataProvider
    {
        IEnumerable<Currency> GetCurrencies();

        IEnumerable<CurrencyRate> GetRates();
    }
}