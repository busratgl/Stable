using System;
using System.Threading;
using System.Threading.Tasks;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Helpers.Models;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyConverterDto;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;
using Stable.Repository.Abstract;

namespace Stable.Business.Concrete.Processes
{
    //public class CurrencyConverterProcess : ICurrencyConverterProcess
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public CurrencyConverterProcess(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    public Task<CurrencyConverterDto> ExecuteAsync(CurrencyConverterRequest currencyConverterRequest, CancellationToken cancellationToken)
    //    {
    //        var sourceRate = 1m;
    //        var targetRate = 1m;
    //        var getCurrencyModel = GetCurrencyHelper.GetCurrency(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, true);

    //        if (currencyConverterRequest.Amount==0)
    //        {
    //            throw new Exception("dnhjsfuwwhf");
    //        }

    //        var converter = currencyConverterRequest.Amount * (sourceRate / targetRate);


    //        return CurrencyConverterDto()
    //        {

    //        }
    //    }
    //}
}
