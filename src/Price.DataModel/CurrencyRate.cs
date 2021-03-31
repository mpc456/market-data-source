namespace Price.DataModel
{
    public class CurrencyRate
    {
        /// <summary>
        ///     ISO 4217 code for currency converting from
        /// </summary>
        public string From { get; set; }

        /// <summary>
        ///     ISO 4217 code for currency converting to
        /// </summary>
        public string To { get; set; }

        /// <summary>
        ///     Exchange rate
        /// </summary>
        public decimal Rate { get; set; }
    }
}