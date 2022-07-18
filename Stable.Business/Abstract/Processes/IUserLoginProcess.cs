using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.UserLoginDto;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IUserLoginProcess
    {
        Task<UserLoginDto> ExecuteAsync(UserLoginRequest userLoginRequest, CancellationToken cancellationToken);
    }
}

