using System.Collections.Generic;

namespace Stable.Business.Concrete.Responses.CurrencyExchangeRate
{
    public class CurrencyExchangeRateDto
    {
        public CurrencyExchangeRateDto()
        {
            this.Currencies = new List<CurrencyExchangeRateItemDto>();
        }
        public List<CurrencyExchangeRateItemDto> Currencies { get; set; }
    }
}
