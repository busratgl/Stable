using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CreateAccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface ICreateAccountProcess
    {
        Task<CreateAccountDto> ExecuteAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken);
    }
}
