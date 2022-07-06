using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
