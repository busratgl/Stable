using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;
using Stable.Core.Utilities.Results.Concrete;

namespace Stable.API.Controllers
{
    public class CurrencyExchangeRateController : BaseController
    {
        private readonly ICurrencyExchangeRateProcess _currencyExchangeRateProcess;
        public CurrencyExchangeRateController(ICurrencyExchangeRateProcess currencyExchangeRateProcess)
        {
            _currencyExchangeRateProcess = currencyExchangeRateProcess;
        }

        [HttpPost("dailyExchangeRate")]
        [AllowAnonymous]
        public DataResult<CurrencyExchangeRateDto> GetDailyCurrencyExchangeRate(CurrencyExchangeRateRequest currencyExchangeRateRequest)
        {
            var result = _currencyExchangeRateProcess.Execute(currencyExchangeRateRequest);
            return new DataResult<CurrencyExchangeRateDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, result);
        }
    }
}
