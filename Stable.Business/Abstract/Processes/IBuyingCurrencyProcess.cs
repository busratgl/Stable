using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.BuyingCurrencyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IBuyingCurrencyProcess
    {
        Task<BuyingCurrencyDto> ExecuteAsync(BuyingCurrencyRequest buyingCurrencyRequest, CancellationToken cancellationToken);
    }
}
