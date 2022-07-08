using Stable.Business.Concrete.Responses.UserRegisterDto;
using Stable.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IUserRegisterProcess
    {
        Task<UserRegisterDto> ExecuteAsync(UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken);
    }
}
