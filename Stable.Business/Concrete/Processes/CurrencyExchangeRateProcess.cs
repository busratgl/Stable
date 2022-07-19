using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;
using Stable.Repository.Abstract;

namespace Stable.Business.Concrete.Processes
{
    public class CurrencyExchangeRateProcess : ICurrencyExchangeRateProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyExchangeRateProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CurrencyExchangeRateDto Execute(CurrencyExchangeRateRequest currencyExchangeRateRequest)
        {
            var result = new CurrencyExchangeRateDto();
            var currencyResult = GetCurrencyHelper.GetCurrency(currencyExchangeRateRequest.Day, currencyExchangeRateRequest.Month, currencyExchangeRateRequest.Year, currencyExchangeRateRequest.IsToday);

            foreach (var currency in currencyResult.Currencies)
            {
                var currencyExchangeRateItemDto = new CurrencyExchangeRateItemDto();
                currencyExchangeRateItemDto.Unit = currency.Unit;
                currencyExchangeRateItemDto.Code = currency.Code;
                currencyExchangeRateItemDto.Name = currency.Name;
                currencyExchangeRateItemDto.BanknoteBuyingRate = currency.BanknoteBuyingRate;
                currencyExchangeRateItemDto.BanknoteSellingRate = currency.BanknoteSellingRate;
                currencyExchangeRateItemDto.ForexBuying = currency.ForexBuying;
                currencyExchangeRateItemDto.ForexSelling = currency.ForexSelling;

                result.Currencies.Add(currencyExchangeRateItemDto);
            }

            return result;
        }
    }
}
