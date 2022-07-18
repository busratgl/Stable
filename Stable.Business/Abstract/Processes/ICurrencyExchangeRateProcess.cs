using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;

namespace Stable.Business.Abstract.Processes
{
    public interface ICurrencyExchangeRateProcess
    {
        CurrencyExchangeRateDto Execute(CurrencyExchangeRateRequest currencyExchangeRateRequest);
    }
}
