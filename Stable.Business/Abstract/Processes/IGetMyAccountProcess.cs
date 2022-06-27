using Stable.Business.Concrete.Processes;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IGetMyAccountProcess
    {
        Task<GetMyAccountDto> ExecuteAsync(GetMyAccountRequest getMyAccountRequest, CancellationToken cancellationToken);
    }
}
