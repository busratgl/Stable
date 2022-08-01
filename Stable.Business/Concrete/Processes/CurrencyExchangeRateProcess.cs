using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;

namespace Stable.Business.Concrete.Processes
{
    public class CurrencyExchangeRateProcess : ICurrencyExchangeRateProcess
    {
        public CurrencyExchangeRateDto Execute(CurrencyExchangeRateRequest currencyExchangeRateRequest)
        {
            var result = new CurrencyExchangeRateDto();
            var currencyResult = GetCurrencyHelper.GetCurrency(currencyExchangeRateRequest.Day, currencyExchangeRateRequest.Month, currencyExchangeRateRequest.Year, currencyExchangeRateRequest.IsToday);

            foreach (var currency in currencyResult.Currencies)
            {
                var currencyExchangeRateItemDto = new CurrencyExchangeRateItemDto()
                {
                    Unit = currency.Unit,
                    Code = currency.Code,
                    Name = currency.Name,
                    BanknoteBuyingRate = currency.BanknoteBuyingRate,
                    BanknoteSellingRate = currency.BanknoteSellingRate,
                    ForexBuying = currency.ForexBuying,
                    ForexSelling = currency.ForexSelling
                };

                result.Currencies.Add(currencyExchangeRateItemDto);
            }

            return result;
        }
    }
}
