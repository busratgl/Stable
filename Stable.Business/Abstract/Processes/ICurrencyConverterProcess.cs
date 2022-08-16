using System.Threading;
using System.Threading.Tasks;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyConverterDto;

namespace Stable.Business.Abstract.Processes
{
    public interface ICurrencyConverterProcess
    {
        Task<CurrencyConverterDto> ExecuteAsync(CurrencyConverterRequest currencyConverterRequest, CancellationToken cancellationToken);
    }
}
