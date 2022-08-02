namespace Stable.Business.Concrete.Responses.CurrencyExchangeRate
{
    public class CurrencyExchangeRateItemDto
    {
        /// <summary>
        /// This property represents currency code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// This property represents currency name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property specifies currency unit
        /// </summary>
        public int Unit { get; set; }

        /// <summary>
        /// This property represents buying rate of exchange
        /// </summary>
        public decimal ForexBuying { get; set; }

        /// <summary>
        /// This property represents selling rate of exchange
        /// </summary>
        public decimal ForexSelling { get; set; }

        /// <summary>
        /// This property represents effective buying rate
        /// </summary>
        public decimal BanknoteBuyingRate { get; set; }

        /// <summary>
        /// This property represents effective selling rate
        /// </summary>
        public decimal BanknoteSellingRate { get; set; }
    }
}
