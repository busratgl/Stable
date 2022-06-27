using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface ICurrencyExchangeRateProcess
    {
        CurrencyExchangeRateDto Execute(CurrencyExchangeRateRequest currencyExchangeRateRequest);
    }
}
