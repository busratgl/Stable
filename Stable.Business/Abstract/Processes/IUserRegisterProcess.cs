using Stable.Business.Concrete.Responses.UserRegisterDto;
using System.Threading;
using System.Threading.Tasks;
using Stable.Business.Concrete.Requests;

namespace Stable.Business.Abstract.Processes
{
    public interface IUserRegisterProcess
    {
        Task<UserRegisterDto> ExecuteAsync(UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken);
    }
}
